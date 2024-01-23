namespace ApplicationLayer.Handlers.Interfaces;

using AzureFunderCommonMessages.DotNet.Interfaces.Response;
using AzureFunderCommonMessages.DotNet.Response;
using AzureFunderCommonMessages.DotNet.Response.SubResponses;
using Models;

public interface ICommonResponseMapper
{
    CommonResponse<T> Map<T>(int quoteId, ApplicationReference applicationReference, T subMessage,
        object requestObject = null, object responseObject = null)
        where T : SubResponse, ISubResponseType, new();
}