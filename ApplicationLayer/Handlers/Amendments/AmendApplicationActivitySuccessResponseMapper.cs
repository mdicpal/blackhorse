namespace ApplicationLayer.Handlers.Amendments;

using ApplicationLayer.Models;
using AzureFunderCommonMessages.DotNet.Response;
using AzureFunderCommonMessages.DotNet.Response.SubResponses;
using AzureFunderCommonMessages.DotNet.Types;
using FunderApi;
using Handlers.Interfaces;
using Interfaces;
using Models;

internal class AmendApplicationActivitySuccessResponseMapper : IAmendApplicationActivitySuccessResponseMapper
{
    private readonly ICommonResponseMapper _commonResponseMapper;

    public AmendApplicationActivitySuccessResponseMapper(ICommonResponseMapper commonResponseMapper)
    {
        _commonResponseMapper = commonResponseMapper;
    }
    public AmendApplicationActivityResponse Map(int quoteId, SendApplicationRequest funderRequest, PutCustomerResponse funderResponse)
    {
        ApplicationReference references = new ()
        {
            CustomerId = Convert.ToInt32(funderResponse.Customer_id), 
            ProposalId = Convert.ToInt32(funderResponse.Proposal_id)
        };
        StatusResponse subMessage = new ()
        {
            ApplicationStatus = StatusResponseType.AmendmentWithFunder,
            Message = $"proposal amendment sent to funder - Proposal Id: {references.ProposalId}, Customer Id: {references.CustomerId}"
        };


        CommonResponse<StatusResponse> commonResponse = _commonResponseMapper.Map(
            quoteId,
            references,
            subMessage,
            funderRequest,
            funderResponse
        );

        return new AmendApplicationActivityResponse
        {
            CommonResponses = { commonResponse }, 
            Success = true,
            ApplicationReference = references,
            ApplicationStatus = subMessage.ApplicationStatus
        };
    }
}