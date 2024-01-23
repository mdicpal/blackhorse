namespace ApplicationLayer.Interfaces
{
    using ApplicationLayer.Models.Activities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FluentValidation.Results;
    using ApplicationLayer.Handlers.Interfaces;
    using AzureFunderCommonMessages.DotNet.Response;
    using AzureFunderCommonMessages.DotNet.Response.SubResponses;
    using ApplicationLayer.Models;
    using AzureFunderCommonMessages.DotNet.Models;

    public interface IValidationFailedResponseMapper
    {
        TActivityResponse Map<TActivityResponse>(int quoteId, string applicationId,
            IEnumerable<ValidationFailure> errors) where TActivityResponse : ActivityResponse, new();
    }
    public class ValidationFailedResponseMapper : IValidationFailedResponseMapper
    {
        private readonly ICommonResponseMapper _commonResponseMapper;

        public ValidationFailedResponseMapper(ICommonResponseMapper commonResponseMapper)
        {
            _commonResponseMapper = commonResponseMapper;
        }
        public TActivityResponse Map<TActivityResponse>(int quoteId, string applicationId,
            IEnumerable<ValidationFailure> errors) where TActivityResponse : ActivityResponse, new()
        {
            List<string> errorList = errors.Select(e => $"{e.PropertyName}: {e.ErrorMessage}").ToList();
            ErrorResponse subMessage = new ErrorResponse("Validation failed", errorList);
            ApplicationReference applicationReference = new ApplicationReference { ProposalId = Convert.ToInt32(applicationId) };

            CommonResponse commonResponse = _commonResponseMapper.Map(
                quoteId,
                applicationReference,
                subMessage,
                null,
                null
            );

            return new TActivityResponse { CommonResponses = { commonResponse } };
        }
    }
}
