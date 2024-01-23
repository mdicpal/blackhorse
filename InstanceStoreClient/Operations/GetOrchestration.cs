namespace InstanceStoreService.Operations;

using InstanceStoreOpenApi;
using Interfaces;
using System.Threading.Tasks;

public class GetOrchestration : IGetOrchestration
{
    private readonly IInstanceStoreClient _client;

    public GetOrchestration(IInstanceStoreClient client)
    {
        _client = client;
    }

    public async Task<Orchestrator> GetAsync(int quoteId)
    {
        return await _client.TryGetOrchestratorForQuoteAsync(quoteId);
    }
}