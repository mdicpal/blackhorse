namespace InstanceStoreService.Interfaces;

using InstanceStoreOpenApi;

public interface IGetOrchestration
{
    Task<Orchestrator> GetAsync(int quoteId);
}