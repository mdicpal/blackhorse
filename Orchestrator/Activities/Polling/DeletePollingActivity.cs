namespace Orchestrator.Activities.Polling;

using ApplicationLayer.Handlers.Polling.Interfaces;
using Domain.Logger;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using Orchestrator.Activities.Application;
using System;
using System.Threading.Tasks;

public class DeletePollingActivity
{
    private readonly IDeletePollingHandler _deletePollingHandler;
    private readonly ILoggerAdapter<DeletePollingActivity> _logger;

    public DeletePollingActivity(IDeletePollingHandler deletePollingHandler, ILoggerAdapter<DeletePollingActivity> logger)
    {
        _deletePollingHandler = deletePollingHandler;
        _logger = logger;
    }
    
    /**
     * <summary>
     * Delete Polling Activity,
     * Delegate this work to the Delete Polling Handler in the ApplicationLayer layer
     * This decouples the orchestrator and the application specific logic
     * </summary>
     */
    [FunctionName(nameof(DeletePollingActivity))]
    public async Task Run([ActivityTrigger] string applicationId)
    {
        try
        {
            await _deletePollingHandler.RunAsync(applicationId);
        }
        catch (Exception ex)
        {
            _logger.LogError(Convert.ToInt32(applicationId), ex.Message, "Exception thrown in Delete Polling Activity Trigger");
            throw;
        }
    }
}