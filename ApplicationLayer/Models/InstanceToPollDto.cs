namespace ApplicationLayer.Models;

public class InstanceToPollDto
{
    public int? Id { get; set; }
    public int QuoteId { get; set; }
    public int CustomerId { get; set; }
    public int ProposalId { get; set; }
    public string InstanceId { get; set; }
    public string DeterministicHash { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    public string ApplicationId { get; set; }
}