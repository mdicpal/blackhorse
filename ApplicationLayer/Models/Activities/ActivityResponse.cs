namespace ApplicationLayer.Models.Activities;

using AzureFunderCommonMessages.DotNet.Response;

public abstract class ActivityResponse
{
    public List<CommonResponse> CommonResponses { get; } = new List<CommonResponse>();
}