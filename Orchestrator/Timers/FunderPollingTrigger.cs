namespace Orchestrator.Timers;

using ApplicationLayer.Extensions;
using ApplicationLayer.Handlers.Polling.Interfaces;
using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Triggers.Interfaces;

public class FunderPollingTrigger
{
    private readonly ILogger<FunderPollingTrigger> _logger;
    private readonly IInstanceToPollRepository _repository;
    private readonly IPollingHandler _pollingHandler;
    private readonly IFunderUpdateEventTrigger _funderUpdateEventTrigger;

    public FunderPollingTrigger(ILogger<FunderPollingTrigger> logger, IInstanceToPollRepository repository, IPollingHandler pollingHandler, IFunderUpdateEventTrigger funderUpdateEventTrigger)
    {
        _logger = logger;
        _repository = repository;
        _pollingHandler = pollingHandler;
        _funderUpdateEventTrigger = funderUpdateEventTrigger;
    }
        
    [FunctionName("FunderPolling")]
    public async Task RunAsync([TimerTrigger("0 */2 * * * *")] TimerInfo myTimer, [DurableClient] IDurableOrchestrationClient durableOrchestrationClient)
    {
        try
        {
            _logger.LogInformation("C# Timer trigger function executed at: {Time}", DateTime.UtcNow);
            List<InstanceToPollDto> instances = await _repository.GetAllAsync();
            foreach (InstanceToPollDto instance in instances)
            {
                FunderUpdate response = await _pollingHandler.RunAsync(instance);
                if (response is null || response.ToDeterministicHash() == instance.DeterministicHash)
                {
                    continue;
                }
                if (response.HasChanged)
                {
                    try
                    {
                        await _funderUpdateEventTrigger.RaiseAsync(durableOrchestrationClient, response, instance.QuoteId);
                    }
                    catch (Exception e)
                    {
                        _logger.LogError(e, "Poling failed for {QuoteID}: {Time}", instance.QuoteId, DateTime.UtcNow);
                    }
                    
                }
            }
        }
        catch(Exception e)
        {
            _logger.LogError(e, "C# Timer trigger function failed at: {Time}", DateTime.UtcNow);
        }
    }
}