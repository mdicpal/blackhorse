namespace ApplicationLayer.Handlers.FunderUpdates;

using AzureFunderCommonMessages.DotNet.Response;
using AzureFunderCommonMessages.DotNet.Response.SubResponses;
using AzureFunderCommonMessages.DotNet.Types;
using Handlers.Interfaces;
using Interfaces;
using Models;

public class FunderUpdateSuccessResponseMapper : IFunderUpdateSuccessResponseMapper
{
    private readonly ICommonResponseMapper _commonResponseMapper;

    public FunderUpdateSuccessResponseMapper(ICommonResponseMapper commonResponseMapper)
    {
        _commonResponseMapper = commonResponseMapper;
    }
    
    public FunderUpdateResponse Map(ApplicationStatusResponse applicationStatusResponse, StatusResponseType applicationStatus, List<string> conditions)
    {
        StatusResponse subMessage = new StatusResponse
        {
            ApplicationStatus = applicationStatus,
            Conditions = conditions,           
        };

        CommonResponse<StatusResponse> commonResponse = _commonResponseMapper.Map(
            applicationStatusResponse.QuoteId,
            applicationStatusResponse.ApplicationReference,
            subMessage,
            null,
            applicationStatusResponse.StatusUpdate
        );
        return new FunderUpdateResponse
        {
            CommonResponses = { commonResponse },
            ApplicationStatus = applicationStatus
        };
    }
}