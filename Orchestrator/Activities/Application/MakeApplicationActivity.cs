namespace Orchestrator.Activities.Application;

using ApplicationLayer.Handlers.MakeApplication.Interfaces;
using ApplicationLayer.Handlers.MakeApplication.Models;
using Domain.Logger;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

public class MakeApplicationActivity
{
    private readonly IMakeApplicationHandler _applicationHandler;
    private readonly ILoggerAdapter<MakeApplicationActivity> _logger;

    public MakeApplicationActivity(IMakeApplicationHandler applicationHandler, ILoggerAdapter<MakeApplicationActivity> logger)
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
    [FunctionName(nameof(MakeApplicationActivity))]
    public async Task<MakeApplicationActivityResponse> Run([ActivityTrigger] MakeApplicationActivityRequest request)
    {
        try
        {
            return await _applicationHandler.Run(request);
        }
        catch (Exception ex)
        {
            _logger.LogError(request.ApplicationRequest.QuoteId, ex.Message, "Exception thrown in Make Application Activity Trigger");
            throw;
        }
    }
}