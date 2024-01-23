namespace InstanceStoreService;

using Domain.Logger;
using InstanceStoreOpenApi;
using System.Net.Http;
using System.Threading.Tasks;

public class InstanceStoreClient : InstanceStore, Interfaces.IInstanceStoreClient
{
    public string FunderCode { get; }
    private readonly ILoggerAdapter<InstanceStoreClient> _log;

    public InstanceStoreClient(HttpClient httpClient, ILoggerAdapter<InstanceStoreClient> log, string funderCode) : base(httpClient)
    {
        _log = log;
        FunderCode = funderCode;
    }
    public async Task<Orchestrator> TryGetOrchestratorForQuoteAsync(int quoteId)
    {
        try
        {
            return await GetOrchestratorAsync(quoteId, FunderCode);
        }
        catch (ApiException)
        {
            _log.LogWarning(quoteId, "no orchestration found for quote");
            return null;
        }
    }
}