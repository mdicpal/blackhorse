namespace Orchestrator.Triggers;

using ApplicationLayer;
using ApplicationLayer.Models;
using Domain.Logger;
using Interfaces;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using System;
using System.Threading.Tasks;

internal class FunderUpdateEventTrigger : IFunderUpdateEventTrigger
{
    private readonly ILoggerAdapter<FunderUpdateEventTrigger> _logger;

    public FunderUpdateEventTrigger(ILoggerAdapter<FunderUpdateEventTrigger> logger)
    {
        _logger = logger;
    }

    public async Task RaiseAsync(IDurableOrchestrationClient durableOrchestrationClient, FunderUpdate funderUpdate, int quoteId)
    {
        try
        {
            _logger.LogInformation(quoteId, "Raising postback event");
            await durableOrchestrationClient.RaiseEventAsync(funderUpdate.InstanceId, ExternalEvents.FunderUpdateEvent, funderUpdate);
        }
        catch (Exception e)
        {
            _logger.LogError(e, quoteId, "Failed to raise postback event for quote {QuoteId}");
        }
    }
}