namespace Orchestrator.Triggers;

using ApplicationLayer;
using AzureFunderCommonMessages.DotNet.Request;
using Domain.Logger;
using Exceptions;
using Interfaces;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using System;
using System.Threading.Tasks;

internal class RaiseAmendmentTrigger : IRaiseAmendmentTrigger
{
    private readonly ILoggerAdapter<RaiseAmendmentTrigger> _logger;

    public RaiseAmendmentTrigger(ILoggerAdapter<RaiseAmendmentTrigger> logger)
    {
        _logger = logger;
    }
        
    public async Task RunAsync(IDurableOrchestrationClient starter, ApplicationRequest request,
        string instanceId)
    {
        try
        {
            _logger.LogInformation(request.QuoteId,"Raising amendment event for Quote {QuoteId}", request.QuoteId);
            await starter.RaiseEventAsync(instanceId, ExternalEvents.Amendment, request);
        }
        catch (Exception e)
        {
            _logger.LogInformation(e, request.QuoteId, "Exception thrown raising amendment event");
            throw new InvalidOrchestrationException("Invalid Orchestration", e);
        }
    }
}