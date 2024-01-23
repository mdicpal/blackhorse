namespace Orchestrator.Activities.Application;

using ApplicationLayer.Handlers.FunderUpdates.Interfaces;
using ApplicationLayer.Handlers.FunderUpdates.Models;
using DeepEqual.Syntax;
using Domain.Logger;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using System;

public class FunderUpdateActivity
{
    private readonly ILoggerAdapter<FunderUpdateActivity> _logger;
    private readonly IFunderUpdateHandler _funderUpdateHandler;

    public FunderUpdateActivity(ILoggerAdapter<FunderUpdateActivity> logger,  IFunderUpdateHandler funderUpdateHandler)
    {
        _logger = logger;
        _funderUpdateHandler = funderUpdateHandler;
    }
        
    /**
     * <summary>
     * Status update Activity,
     * Delegate this work to the Postback Handler in the ApplicationLayer layer
     * This decouples the orchestrator and the application specific logic
     * </summary>
     */
    [FunctionName(nameof(FunderUpdateActivity))]
    public FunderUpdateResponse Run([ActivityTrigger] ApplicationStatusResponse request)
    {       
        try
        {
            _logger.LogInformation(request.QuoteId, "Status update activity function started");
            return _funderUpdateHandler.Run(request);
        }
        catch (Exception ex)
        {
            _logger.LogError(request.QuoteId, ex.Message, "Exception thrown in Funder Update Activity Trigger");
            throw;
        }        
    }
}