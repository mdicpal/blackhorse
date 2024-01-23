namespace ApplicationLayer.Handlers.Amendments
{
    using FunderApi;
    using FunderService.Interfaces;
    using FunderService.Mappers.Interfaces;
    using Interfaces;
    using Models;
    using ApplicationLayer.Interfaces;
    using AzureFunderCommonMessages.DotNet.Models;
    using System.ComponentModel.DataAnnotations;
    using FluentValidation;
    using ValidationException = FluentValidation.ValidationException;
    using Extensions.ApiExceptions;
    using ApplicationLayer.Handlers.MakeApplication.Models;
    using Microsoft.Extensions.Logging;

    internal class AmendApplicationHandler : IAmendApplicationHandler
    {
        private readonly ICustomerMapper _customerMapper;
        private readonly IAmendApplicationActivitySuccessResponseMapper _successResponseMapper;
        private readonly IAmendApplicationActivityFailedResponseMapper _amendApplicationActivityFailedResponseMapper;
        private readonly IFunderClient _funderClient;
        private readonly ILogger<AmendApplicationHandler> _logger;
        private readonly IValidationFailedResponseMapper _validationFailedResponseMapper;

        public AmendApplicationHandler(
            IFunderClient funderClient,
            ICustomerMapper customerMapper,
            IAmendApplicationActivitySuccessResponseMapper successResponseMapper,
            IAmendApplicationActivityFailedResponseMapper amendApplicationActivityFailedResponseMapper,
            IValidationFailedResponseMapper validationFailedResponseMapper,
            ILogger<AmendApplicationHandler> logger)
        {
            _funderClient = funderClient;
            _customerMapper = customerMapper;
            _successResponseMapper = successResponseMapper;
            _amendApplicationActivityFailedResponseMapper = amendApplicationActivityFailedResponseMapper;
            _validationFailedResponseMapper = validationFailedResponseMapper;
            _logger = logger;
        }

        public async Task<AmendApplicationActivityResponse> Run(AmendApplicationActivityRequest request)
        {
            SendApplicationRequest funderRequest = null;
            int majorDealerId = Convert.ToInt32(Environment.GetEnvironmentVariable("x-lbg-major-dealerId"));
            int minorDealerId = Convert.ToInt32(Environment.GetEnvironmentVariable("x-lbg-minor-dealerId"));
            string idempotency = DateTime.Now.ToString("yyyymmddhhmmss");
            try
            {
                _logger.LogInformation(request.ApplicationRequest.QuoteId, "Starting application amendment");
                funderRequest = _customerMapper.Map(request.ApplicationRequest, request.ApplicationReference.CustomerId, request.ApplicationReference.ProposalId);
                PutCustomerResponse funderResponse = await _funderClient.UpdateApplicationAsync(majorDealerId,minorDealerId,idempotency,funderRequest, request.ApplicationReference.CustomerId);
                return _successResponseMapper.Map(request.ApplicationRequest.QuoteId, funderRequest, funderResponse);
            }
            catch (ValidationException e)
            {
                _logger.LogInformation(e, "Validation exception returned {Errors}", e.Errors);
                return _validationFailedResponseMapper.Map<AmendApplicationActivityResponse>(request.ApplicationRequest.QuoteId, null, e.Errors);
            }
            catch (ApiException<GenericErrorResponse> exception)
            {
                _logger.LogWarning(exception, "Funder returned a error on amendment application");
                return _amendApplicationActivityFailedResponseMapper.Map(request.ApplicationRequest.QuoteId, funderRequest, exception.Result);
            }
            catch (ApiException<string> exception) when (exception.IsNonTransientError())
            {
                _logger.LogWarning(exception, "Funder returned a error on amendment application");
                return _amendApplicationActivityFailedResponseMapper.Map(request.ApplicationRequest.QuoteId, exception.Result, funderRequest);
            }
            catch (ApiException exception) when (exception.IsNonTransientError())
            {
                _logger.LogWarning(exception, "Funder returned a error on amendment application");
                return _amendApplicationActivityFailedResponseMapper.Map(request.ApplicationRequest.QuoteId, exception.Message, funderRequest);
            }
            catch (Exception e)
            {
                _logger.LogError(e,"Failed to send amendment application request");
                throw;
            }
        }
    }
}