namespace Orchestrator.Activities.Application;

using ApplicationLayer.Handlers.Amendments.Interfaces;
using ApplicationLayer.Handlers.Amendments.Models;
using Domain.Logger;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

public class AmendApplicationActivity
{
    private readonly IAmendApplicationHandler _applicationHandler;
    private readonly ILoggerAdapter<AmendApplicationActivity> _logger;

    public AmendApplicationActivity(IAmendApplicationHandler applicationHandler, ILoggerAdapter<AmendApplicationActivity> logger)
    {
        _applicationHandler = applicationHandler;
        _logger = logger;
    }
        
    /**
     * <summary>
     * Amend ApplicationLayer Activity,
     * Delegate this work to the Amend ApplicationLayer Handler in the ApplicationLayer layer
     * This decouples the orchestrator and the application specific logic
     * </summary>
     */
    [FunctionName(nameof(AmendApplicationActivity))]
    public async Task<AmendApplicationActivityResponse> Run([ActivityTrigger] AmendApplicationActivityRequest request)
    {
        try
        {
            return await _applicationHandler.Run(request);
        }
        catch (Exception ex)
        {
            _logger.LogError(request.ApplicationRequest.QuoteId, ex.Message, "Exception thrown in Amend Application Activity Trigger");
            throw;
        }
    }
}