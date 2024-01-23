namespace InstanceStoreService.Operations;

using Interfaces;
using System.Threading.Tasks;

public class PutOrchestration : IPutOrchestration
{
    private readonly IInstanceStoreClient _client;

    public PutOrchestration(IInstanceStoreClient client)
    {
        _client = client;
    }

    public async Task CreateAsync(int quoteId, string instanceId)
    {
        var body = new InstanceStoreOpenApi.Request() { InstanceId = instanceId };
        await _client.PutOrchestratorAsync(quoteId, _client.FunderCode, body);
    }

    public async Task UpdateFunderReferenceAsync(int quoteId, string instanceId, string funderReference)
    {
        var body = new InstanceStoreOpenApi.Request() { ApplicationId = funderReference, InstanceId = instanceId };
        await _client.PutOrchestratorAsync(quoteId, _client.FunderCode, body);
    }
}