namespace Orchestrator.Activities.Application;

using ApplicationLayer.Handlers.Amendments.Interfaces;
using ApplicationLayer.Handlers.Amendments.Models;
using Domain.Logger;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

public class AmendSubmitActivity
{
    private readonly IAmendSubmitHandler _applicationHandler;
    private readonly ILoggerAdapter<AmendSubmitActivityRequest> _logger;
    public AmendSubmitActivity(IAmendSubmitHandler applicationHandler, ILoggerAdapter<AmendSubmitActivityRequest> logger)
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
    [FunctionName(nameof(AmendSubmitActivity))]
    public async Task<AmendSubmitActivityResponse> Run([ActivityTrigger] AmendSubmitActivityRequest request)
    {
        try
        {
            return await _applicationHandler.Run(request);
        }
        catch (Exception ex)
        {
            _logger.LogError(request.ApplicationRequest.QuoteId,ex.Message, "Exception thrown in Amend Submit Activity Trigger");
            throw;
        }
    }
}