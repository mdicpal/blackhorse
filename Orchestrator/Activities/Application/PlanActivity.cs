namespace Orchestrator.Activities.Application;

using ApplicationLayer.Handlers.Plans.Interfaces;
using Domain.Logger;
using FunderApi;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using System;
using System.Threading.Tasks;

public class GetPlanActivity
{
    private readonly IPlanHandler _planHandler;
    private readonly ILoggerAdapter<GetPlanActivity> _logger;

    public GetPlanActivity(IPlanHandler planHandler, ILoggerAdapter<GetPlanActivity> logger)
    {
        _planHandler = planHandler;
        _logger = logger;

    }
        
    /**
     * <summary>
     * Amend ApplicationLayer Activity,
     * Delegate this work to the Amend ApplicationLayer Handler in the ApplicationLayer layer
     * This decouples the orchestrator and the application specific logic
     * </summary>
     */
    [FunctionName(nameof(GetPlanActivity))]
    public async Task<GetPlanResponse> Run([ActivityTrigger] int planId)
    {
        try {
            return await _planHandler.Run(planId);
        }
        catch(Exception e) {
            _logger.LogError(e, planId, "Failed to Get Plan Activity");
            throw;
        }
        
    }
}