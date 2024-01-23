namespace ApplicationLayer.Handlers.NotTakenUp;

using ApplicationLayer.Models;
using AzureFunderCommonMessages.DotNet.Response;
using AzureFunderCommonMessages.DotNet.Response.SubResponses;
using AzureFunderCommonMessages.DotNet.Types;
using FunderApi;
using Handlers.Interfaces;
using Interfaces;
using Models;
using System.ServiceModel.Channels;

public class NotTakenUpActivitySuccessResponseMapper : INotTakenUpActivitySuccessResponseMapper
{
    private readonly ICommonResponseMapper _commonResponseMapper;

    public NotTakenUpActivitySuccessResponseMapper(ICommonResponseMapper commonResponseMapper)
    {
        _commonResponseMapper = commonResponseMapper;
    }
    public NotTakenUpActivityResponse Map(int quoteId, string customerId, string proposalId, NotTakenUpResponse funderResponse)
    {
        ApplicationReference references = new ApplicationReference
        {
            CustomerId = Convert.ToInt32(customerId),
            ProposalId = Convert.ToInt32(proposalId),
        };
        StatusResponse subMessage = new StatusResponse
        {
            ApplicationStatus = StatusResponseType.ReceivedOK,
            Message  = $"Post Submit sent to funder - Proposal Id: {references.ProposalId}, Customer Id: {references.CustomerId}"
        };
        CommonResponse<StatusResponse> commonResponse = _commonResponseMapper.Map(
            quoteId,
            references,
            subMessage,
            proposalId,
            funderResponse
        );

        return new NotTakenUpActivityResponse
        {
            CommonResponses = { commonResponse },
            Success = true,
            ApplicationReference = references,
            ApplicationStatus = subMessage.ApplicationStatus
        };
    }
}