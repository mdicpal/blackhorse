namespace ApplicationLayer.Handlers.Amendments;

using ApplicationLayer.Handlers.Amendments.Interfaces;
using ApplicationLayer.Handlers.Amendments.Models;
using FunderApi;
using FunderService.Interfaces;
using ApplicationLayer.Interfaces;
using ValidationException = FluentValidation.ValidationException;
using Extensions.ApiExceptions;
using Microsoft.Extensions.Logging;

internal class AmendSubmitHandler : IAmendSubmitHandler
{

    private readonly IAmendSubmitSuccessResponseMapper _successResponseMapper;
    private readonly IAmendSubmitActivityFailedResponseMapper _failedResponseMapper;
    private readonly IFunderClient _funderClient;
    private readonly ILogger<AmendSubmitHandler> _logger;
    private readonly IValidationFailedResponseMapper _validationFailedResponseMapper;

    public AmendSubmitHandler(
        IFunderClient funderClient,
        IAmendSubmitSuccessResponseMapper successResponseMapper,
        IAmendSubmitActivityFailedResponseMapper failedResponseMapper,
        IValidationFailedResponseMapper validationFailedResponseMapper,
        ILogger<AmendSubmitHandler> logger)
    {
        _funderClient = funderClient;
        _successResponseMapper = successResponseMapper;
        _failedResponseMapper = failedResponseMapper;
        _validationFailedResponseMapper = validationFailedResponseMapper;
        _logger = logger;
    }

    public async Task<AmendSubmitActivityResponse> Run(AmendSubmitActivityRequest amendmentSubmitActivityRequest)
    {
        PostSubmitResponse funderResponse = null;
        try
        {
            int majorDealerId = Convert.ToInt32(Environment.GetEnvironmentVariable("x-lbg-major-dealerId"));
            int minorDealerId = Convert.ToInt32(Environment.GetEnvironmentVariable("x-lbg-minor-dealerId"));
            string idempotency = DateTime.Now.ToString("yyyymmddhhmmss");
            funderResponse = await _funderClient.SendSubmitAsync(majorDealerId,minorDealerId,idempotency,Convert.ToInt32(amendmentSubmitActivityRequest?.CustomerId), Convert.ToInt32(amendmentSubmitActivityRequest?.ProposalId));
            _logger.LogInformation(amendmentSubmitActivityRequest.ApplicationRequest.QuoteId, "The submit request is successfully submitted to the funder");
            return _successResponseMapper.Map(amendmentSubmitActivityRequest.ApplicationRequest.QuoteId, amendmentSubmitActivityRequest.CustomerId, amendmentSubmitActivityRequest.ProposalId, funderResponse);
        }
        catch (ValidationException e)
        {
            _logger.LogInformation(e, "Validation exception returned, {Errors}", e.Errors);
            return _validationFailedResponseMapper.Map<AmendSubmitActivityResponse>(amendmentSubmitActivityRequest.ApplicationRequest.QuoteId, Convert.ToString(amendmentSubmitActivityRequest.ApplicationId), e.Errors);
        }
        catch (ApiException<GenericErrorResponse> exception)
        {
            _logger.LogWarning(exception, "Funder returned a error on amendment application submit");
            return _failedResponseMapper.Map(amendmentSubmitActivityRequest.ApplicationRequest.QuoteId, Convert.ToString(amendmentSubmitActivityRequest?.CustomerId), Convert.ToString(amendmentSubmitActivityRequest?.ProposalId), exception, exception.Result);
        }
        catch (ApiException<string> exception) when (exception.IsNonTransientError())
        {
            _logger.LogWarning(exception, "Funder returned a error on amendment application submit");
            return _failedResponseMapper.Map(amendmentSubmitActivityRequest.ApplicationRequest.QuoteId, Convert.ToString(amendmentSubmitActivityRequest?.CustomerId), Convert.ToString(amendmentSubmitActivityRequest?.ProposalId), exception, null);
        }
        catch (ApiException exception) when (exception.IsNonTransientError())
        {
            _logger.LogWarning(exception, "Funder returned a error on amendment application submit");
            return _failedResponseMapper.Map(amendmentSubmitActivityRequest.ApplicationRequest.QuoteId, Convert.ToString(amendmentSubmitActivityRequest?.CustomerId), Convert.ToString(amendmentSubmitActivityRequest?.ProposalId), exception, null);
        }
        catch (Exception e)
        {
            _logger.LogError(e,"Failed to send amendment application submit request");
            throw;
        }
    }
}