namespace ApplicationLayer.Handlers.MakeApplication.Models;

using AzureFunderCommonMessages.DotNet.Request;

public class MakeApplicationActivityRequest
{
    public ApplicationRequest ApplicationRequest { get; init; }
    public int? ApplicationId { get; init; }
}