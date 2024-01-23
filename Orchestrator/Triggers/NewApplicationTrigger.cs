namespace Orchestrator.Triggers;

using AzureFunderCommonMessages.DotNet.Request;
using Domain.Logger;
using Interfaces;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Orchestrator_1_0;
using System.Threading.Tasks;

internal class NewApplicationTrigger : INewApplicationTrigger
{
    private readonly ILoggerAdapter<NewApplicationTrigger> _logger;

    public NewApplicationTrigger(ILoggerAdapter<NewApplicationTrigger> logger)
    {
        _logger = logger;
    }
        
    public async Task RunAsync(IDurableOrchestrationClient starter, ApplicationRequest request)
    {
        _logger.LogWarning(request.QuoteId, "Starting new orchestration");
        await starter.StartNewAsync(nameof(OrchestratorV1_0), null, request);
    }
}