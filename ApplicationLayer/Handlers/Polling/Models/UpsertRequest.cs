namespace ApplicationLayer.Handlers.Polling.Models;

using FunderApi;

public class UpsertRequest
{
    public string ApplicationId { get; set; }
    public int ProposalId { get; set; }
    public int CustomerId { get; set; }
    public int QuoteId { get; set; }
    public string InstanceId { get; set; }
    public Decision FunderResponse { get; set; }
}