namespace ApplicationLayer.Handlers.NotTakenUp;

using ApplicationLayer.Handlers.NotTakenUp.Interfaces;
using ApplicationLayer.Models;
using AzureFunderCommonMessages.DotNet.Response;
using AzureFunderCommonMessages.DotNet.Response.SubResponses;
using AzureFunderCommonMessages.DotNet.Types;
using FunderApi;
using Handlers.Interfaces;
using Models;
using System.ServiceModel.Channels;

public class NotTakenUpActivityFailedResponseMapper :  INotTakenUpActivityFailedResponseMapper
{
    private readonly ICommonResponseMapper _commonResponseMapper;

    public NotTakenUpActivityFailedResponseMapper(ICommonResponseMapper commonResponseMapper)
    {
        _commonResponseMapper = commonResponseMapper;
    }
    public NotTakenUpActivityResponse Map(int quoteId, string customerId, string proposalId, NotTakenUpResponse funderResponse, Exception exception)
    {
        FunderErrors subMessage = new FunderErrors()
        {
            Errors = new List<string> { exception.InnerException?.Message ?? exception.Message }
        };
        CommonResponse<FunderErrors> commonResponse = _commonResponseMapper.Map(
            quoteId,
            null,
            subMessage,
            customerId,
            funderResponse
        );
        return new NotTakenUpActivityResponse { CommonResponses = { commonResponse }, Success = true };
    }
}
