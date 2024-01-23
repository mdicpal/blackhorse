namespace ApplicationLayer.Handlers.NotTakenUp.Models
{
    using ApplicationLayer.Models.Activities;
    using ApplicationLayer.Models;
    using AzureFunderCommonMessages.DotNet.Types;
   
    public class NotTakenUpActivityResponse : ActivityResponse
    {
        public bool Success { get; set; }
        public ApplicationReference ApplicationReference { get; set; }
        public StatusResponseType ApplicationStatus { get; set; }
    }
}
