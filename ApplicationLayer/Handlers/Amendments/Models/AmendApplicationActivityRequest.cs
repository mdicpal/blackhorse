namespace ApplicationLayer.Handlers.Amendments.Models;

using ApplicationLayer.Models;
using AzureFunderCommonMessages.DotNet.Request;

public class AmendApplicationActivityRequest
{
    public ApplicationRequest ApplicationRequest { get; init; }
    public ApplicationReference ApplicationReference { get; set; }
}