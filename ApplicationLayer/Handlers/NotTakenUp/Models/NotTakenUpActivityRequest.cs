namespace ApplicationLayer.Handlers.NotTakenUp.Models
{
    using AzureFunderCommonMessages.DotNet.Request;    

    public class NotTakenUpActivityRequest
    {
        public ApplicationRequest ApplicationRequest { get; init; }
        public string ProposalId { get; init; }
        public string CustomerId { get; init; }
        public int? ApplicationId { get; init; }
    }
}
