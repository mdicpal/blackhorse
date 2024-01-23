namespace ApplicationLayer.Handlers.MakeApplication.Models;

using ApplicationLayer.Models;
using ApplicationLayer.Models.Activities;

public class MakeApplicationActivityResponse : ActivityResponse
{
    public bool Success { get; set; }
    public string ApplicationId { get; set; }
    public ApplicationReference ApplicationReference { get; set; }
}