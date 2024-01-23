namespace ApplicationLayer.Handlers.FunderUpdates.Models;

using AzureFunderCommonMessages.DotNet.Response;
using AzureFunderCommonMessages.DotNet.Types;

public class FunderUpdateResponse
{
    public List<CommonResponse> CommonResponses { get; } = new();
    public StatusResponseType ApplicationStatus { get; init; }
}