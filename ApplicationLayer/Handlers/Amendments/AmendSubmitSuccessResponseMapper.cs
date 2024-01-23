namespace ApplicationLayer.Handlers.Amendments;

using ApplicationLayer.Handlers.Amendments.Interfaces;
using ApplicationLayer.Handlers.Amendments.Models;
using ApplicationLayer.Models;
using AzureFunderCommonMessages.DotNet.Response;
using AzureFunderCommonMessages.DotNet.Response.SubResponses;
using AzureFunderCommonMessages.DotNet.Types;
using FunderApi;
using Handlers.Interfaces;

internal class AmendSubmitSuccessResponseMapper : IAmendSubmitSuccessResponseMapper
{
    private readonly ICommonResponseMapper _commonResponseMapper;

    public AmendSubmitSuccessResponseMapper(ICommonResponseMapper commonResponseMapper)
    {
        _commonResponseMapper = commonResponseMapper;
    }
    public AmendSubmitActivityResponse Map(int quoteId, string customer_id, string proposal_id, PostSubmitResponse funderResponse)
    {
        ApplicationReference references = new ApplicationReference
        {
            CustomerId = Convert.ToInt32(customer_id),
            ProposalId = Convert.ToInt32(proposal_id),// TO DO
        };
        StatusResponse subMessage = new StatusResponse
        {
            ApplicationStatus = StatusResponseType.ReceivedOK,
            Message = $"Post Submit sent to funder - Proposal Id: {references.ProposalId}, Customer Id: {references.CustomerId}"
        };
        CommonResponse<StatusResponse> commonResponse = _commonResponseMapper.Map(
            quoteId,
            references,
            subMessage,
            proposal_id,
            funderResponse
        );

        return new AmendSubmitActivityResponse
        {
            CommonResponses = { commonResponse },
            Success = true,
            ApplicationReference = references,
            ApplicationStatus = subMessage.ApplicationStatus
        };
    }
}