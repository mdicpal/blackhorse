namespace ApplicationLayer.Handlers.Amendments.Models;

using ApplicationLayer.Models;
using ApplicationLayer.Models.Activities;
using AzureFunderCommonMessages.DotNet.Types;

public class AmendApplicationActivityResponse : ActivityResponse
{
    public bool Success { get; set; }
    public ApplicationReference ApplicationReference { get; set; }
    public StatusResponseType ApplicationStatus { get; set; }
}