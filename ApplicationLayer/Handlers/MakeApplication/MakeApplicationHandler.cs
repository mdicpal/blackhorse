namespace ApplicationLayer.Handlers.MakeApplication;

using ApplicationLayer.Interfaces;
using AzureFunderCommonMessages.DotNet.Models;
using FunderApi;
using FunderService.Interfaces;
using FunderService.Mappers.Interfaces;
using Interfaces;
using Microsoft.Extensions.Logging;
using Models;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;
using Extensions.ApiExceptions;

internal class MakeApplicationHandler : IMakeApplicationHandler
{
    private readonly ICustomerMapper _customerMapper;
    private readonly IMakeApplicationActivitySuccessResponseMapper _successResponseMapper;
    private readonly IMakeApplicationActivityFailedResponseMapper _failedResponseMapper;
    private readonly IFunderClient _funderClient;
    private readonly ILogger<MakeApplicationHandler> _logger;
    private readonly IValidationFailedResponseMapper _validationFailedResponseMapper;

    public MakeApplicationHandler(
        IFunderClient funderClient,
        ICustomerMapper customerMapper,
        IMakeApplicationActivitySuccessResponseMapper successResponseMapper,
        IMakeApplicationActivityFailedResponseMapper failedresponseMapper,
        IValidationFailedResponseMapper validationFailedResponseMapper,
        ILogger<MakeApplicationHandler> logger)
    {
        _funderClient = funderClient;
        _customerMapper = customerMapper;
        _successResponseMapper = successResponseMapper;
        _failedResponseMapper = failedresponseMapper;
        _validationFailedResponseMapper = validationFailedResponseMapper;
        _logger = logger;
    }

    public async Task<MakeApplicationActivityResponse> Run(MakeApplicationActivityRequest request)
    {
        SendApplicationRequest funderRequest = null;
      
        int majorDealerId = Convert.ToInt32(Environment.GetEnvironmentVariable("x-lbg-major-dealerId"));
        int minorDealerId = Convert.ToInt32(Environment.GetEnvironmentVariable("x-lbg-minor-dealerId"));
        string idempotency = DateTime.Now.ToString("yyyymmddhhmmss");

        try
        {
            funderRequest = _customerMapper.Map(request.ApplicationRequest, null, null);
            SendApplicationResponse funderResponse = await _funderClient.SendApplicationAsync(majorDealerId,minorDealerId,idempotency, funderRequest);
            return _successResponseMapper.Map(request.ApplicationRequest.QuoteId, funderRequest, funderResponse);
        }
        catch (ValidationException e)
        {
            _logger.LogInformation(e, "Validation exception returned, {Errors}", e.Errors);
            return _validationFailedResponseMapper.Map<MakeApplicationActivityResponse>(request.ApplicationRequest.QuoteId, null, e.Errors);
        }
        catch (ApiException<GenericErrorResponse> exception)
        {
            _logger.LogWarning(exception, "Funder returned a error on make application");
            return _failedResponseMapper.Map(request.ApplicationRequest.QuoteId, funderRequest, exception.Result);
        }
        catch (ApiException<string> exception) when (exception.IsNonTransientError())
        {
            _logger.LogWarning(exception, "Funder returned a error on make application");
            return _failedResponseMapper.Map(request.ApplicationRequest.QuoteId, exception.Result, funderRequest);
        }
        catch (ApiException exception) when (exception.IsNonTransientError())
        {
            _logger.LogWarning(exception, "Funder returned a error on make application");
            return _failedResponseMapper.Map(request.ApplicationRequest.QuoteId, exception.Message, funderRequest);
        }
        catch (Exception e)
        {
            _logger.LogError(e,"Failed to send application request");
            throw;
        }
    }
}