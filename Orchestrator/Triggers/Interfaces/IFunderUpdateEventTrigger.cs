namespace Orchestrator.Triggers.Interfaces;

using ApplicationLayer.Models;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using System.Threading.Tasks;

public interface IFunderUpdateEventTrigger
{
    Task RaiseAsync(IDurableOrchestrationClient durableOrchestrationClient, FunderUpdate funderUpdate, int quoteId);
}