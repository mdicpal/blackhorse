namespace ApplicationLayer.Models.Activities.InstanceStore;

public class StoreApplicationIdActivityRequest
{
    public string ApplicationId { get; init; }
    public string InstanceId { get; init; }
    public int QuoteId { get; init; }
}