namespace InstanceStoreService.Interfaces;

using InstanceStoreOpenApi;
using System.Threading.Tasks;

public interface IInstanceStoreClient
{
    Task<Response> PutOrchestratorAsync(int quoteId, string funderCode, Request data);
    Task<StatusCount> CountStatusAsync();
    /// <summary>
    /// Contacts the instance store for orchestration with the given quote Id.
    /// </summary>
    /// <param name="quoteId"></param>
    /// <returns>If found then we will return the orchestration. <br /> If not will return null</returns>
    Task<Orchestrator> TryGetOrchestratorForQuoteAsync(int quoteId);
    public string FunderCode { get; }
}