namespace Orchestrator.Activities.Polling;

using ApplicationLayer.Handlers.Polling.Interfaces;
using ApplicationLayer.Handlers.Polling.Models;
using Domain.Logger;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using Orchestrator.Activities.Application;
using System;
using System.Threading.Tasks;

public class UpsertPollingActivity
{
    private readonly IUpsertPollingHandler _upsertPollingHandler;
    private readonly ILoggerAdapter<UpsertPollingActivity> _logger;

    public UpsertPollingActivity(IUpsertPollingHandler upsertPollingHandler, ILoggerAdapter<UpsertPollingActivity> logger)
    {
        _upsertPollingHandler = upsertPollingHandler;
        _logger = logger;
    }
    
    /**
     * <summary>
     * Upsert Polling Activity,
     * Delegate this work to the Upsert Polling Handler in the ApplicationLayer layer
     * This decouples the orchestrator and the application specific logic
     * </summary>
     */
    [FunctionName(nameof(UpsertPollingActivity))]
    public async Task Run([ActivityTrigger] UpsertRequest request)
    {
        try
        {
            await _upsertPollingHandler.RunAsync(request);
        }
        catch (Exception ex)
        {
            _logger.LogError(request.QuoteId, ex.Message, "Exception thrown in Upsert Polling Activity Trigger");
            throw;
        }
    }
}