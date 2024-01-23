namespace ApplicationLayer.Handlers.MakeApplication;

using ApplicationLayer.Models;
using AzureFunderCommonMessages.DotNet.Response;
using AzureFunderCommonMessages.DotNet.Response.SubResponses;
using AzureFunderCommonMessages.DotNet.Types;
using FunderApi;
using Handlers.Interfaces;
using Interfaces;
using Models;

internal class MakeApplicationActivitySuccessResponseMapper : IMakeApplicationActivitySuccessResponseMapper
{
    private readonly ICommonResponseMapper _commonResponseMapper;

    public MakeApplicationActivitySuccessResponseMapper(ICommonResponseMapper commonResponseMapper)
    {
        _commonResponseMapper = commonResponseMapper;
    }
    public MakeApplicationActivityResponse Map(int quoteId, SendApplicationRequest funderRequest, SendApplicationResponse funderResponse)
    {
        string applicationId = UniqueApplicationId();
        StatusResponse subMessage = new StatusResponse
        {
            ApplicationStatus = StatusResponseType.ReceivedOK,
            Message = $"New proposal received by funder - ApplicationID: {applicationId}"
        };

        ApplicationReference references = new ApplicationReference
        {
            CustomerId = Convert.ToInt32(funderResponse.Customer_id), 
            ProposalId = Convert.ToInt32(funderResponse.Proposal_id)
        };

        CommonResponse<StatusResponse> commonResponse = _commonResponseMapper.Map(
            quoteId,
            references,
            subMessage,
            funderRequest,
            funderResponse
        );

        return new MakeApplicationActivityResponse
        {
            CommonResponses = { commonResponse }, 
            ApplicationId = applicationId,
            Success = true,
            ApplicationReference = references
        };
    }

    private static string UniqueApplicationId()
    {
        Guid newGuid = Guid.NewGuid();
        return newGuid.ToString();
    }
}