namespace ApplicationLayer.Models;

using AzureFunderCommonMessages.DotNet.Request;
using AzureFunderCommonMessages.DotNet.Types;

public class Orchestration
{
    public ApplicationRequest ApplicationRequest { get; set; }
    public int QuoteId { get; set; }
    public string ApplicationId { get; set; }
    public StatusResponseType? ApplicationStatus { get; set; } = StatusResponseType.ReceivedOK;
    public ApplicationReference ApplicationReference { get; set; }
}