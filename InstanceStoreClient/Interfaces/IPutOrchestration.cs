namespace InstanceStoreService.Interfaces;

public interface IPutOrchestration
{
    Task CreateAsync(int quoteId, string instanceId);

    Task UpdateFunderReferenceAsync(int quoteId, string instanceId, string funderReference);
}