namespace ApplicationLayer.Models.Activities.InstanceStore;

public class StoreInstanceIdActivityRequest
{
    public string InstanceId { get; init; } = null!;
    public int QuoteId { get; init; }
}