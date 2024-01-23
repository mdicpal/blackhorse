namespace Orchestrator.Activities.Application;

using ApplicationLayer.Handlers.NotTakenUp.Interfaces;
using ApplicationLayer.Handlers.NotTakenUp.Models;
using Domain.Logger;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

public class NotTakenUpActivity
{
    private readonly INotTakenUpHandler _applicationHandler;
    private readonly ILoggerAdapter<NotTakenUpActivity> _logger;
    public NotTakenUpActivity(INotTakenUpHandler applicationHandler, ILoggerAdapter<NotTakenUpActivity> logger)
    {
        _applicationHandler = applicationHandler;
        _logger = logger;
    }   
    /**
     * <summary>
     * Make ApplicationLayer Activity,
     * Delegate this work to the Make ApplicationLayer Handler in the ApplicationLayer layer
     * This decouples the orchestrator and the application specific logic
     * </summary>
     */
    [FunctionName(nameof(NotTakenUpActivity))]
    public async Task<NotTakenUpActivityResponse> Run([ActivityTrigger] NotTakenUpActivityRequest request)
    {
        try
        {
            return await _applicationHandler.Run(request);
        }
        catch(Exception e)
        {
            _logger.LogError(request.ApplicationRequest.QuoteId, e.Message, "Failed to Not TakenUp Activity");
            throw;
        }
        
    }
}