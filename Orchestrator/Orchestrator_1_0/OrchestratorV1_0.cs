using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;

namespace Orchestrator.Orchestrator_1_0;

using ApplicationLayer.Models;
using Domain.Logger;
using Microsoft.Extensions.Logging;
using System;

public partial class OrchestratorV1_0
{
    private readonly ILoggerAdapter<OrchestratorV1_0> _logger;
    private Orchestration _orchestration;
    private IDurableOrchestrationContext _context;
    private readonly RetryOptions _retryOptions = RetryOptionsBuilder.GetRetryOptions();

    public OrchestratorV1_0(ILoggerAdapter<OrchestratorV1_0> logger)
    {
        _logger = logger;
    }

    /**
     * <summary>
     * Orchestration Loop, this is the main loops for any funders orchestration
     * </summary>
     */
    [FunctionName(nameof(OrchestratorV1_0))]
    public async Task<bool> RunOrchestrator([OrchestrationTrigger] IDurableOrchestrationContext context)
    {
        try
        {
            Setup(context);
            await CallStoreInstanceIdActivityAsync();
            if (!await CallMakeApplicationActivityAsync())
            {
                return false;
            }

            await CallUpsertPollingActivityAsync(null);
            await CallStoreApplicationIdActivityAsync();
            await RunEventLoopAsync();
            await CallDeletePollingActivityAsync();
            return true;
        }
        catch (Exception e)
        {
            await SendExceptionToServiceBus(e, "Orchestration Failure");
            return false;
        }
    }

    private void Log(string message, LogLevel logLevel = LogLevel.Information)
    {
        if (!_context.IsReplaying)
        {
            _logger.Log(logLevel,  _orchestration.QuoteId, "{Message}", message);
        }
    }

    private void Log(Exception exception, string message, LogLevel logLevel = LogLevel.Error)
    {
        if (!_context.IsReplaying)
        {
            _logger.Log(logLevel, exception, _orchestration.QuoteId, "{Message}", message);
        }
    }
}