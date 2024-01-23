namespace ApplicationLayer.Handlers.FunderUpdates.Interfaces;

using AzureFunderCommonMessages.DotNet.Types;
using Models;

public interface IFunderUpdateSuccessResponseMapper
{
    FunderUpdateResponse Map(ApplicationStatusResponse applicationStatusResponse, StatusResponseType applicationStatus, List<string> conditions);
}