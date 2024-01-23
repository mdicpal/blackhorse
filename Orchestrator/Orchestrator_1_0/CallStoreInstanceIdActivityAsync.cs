namespace Orchestrator.Orchestrator_1_0;

using Activities.InstanceStore;
using ApplicationLayer.Models.Activities.InstanceStore;
using System;
using System.Threading.Tasks;

public partial class OrchestratorV1_0
{
    /**
     * <summary>
     * Store the orchestration instance id in the instance store,
     * This allows future events to be raised against this orchestration
     * </summary>
     */
    private async Task CallStoreInstanceIdActivityAsync()
    {
        try
        {
            StoreInstanceIdActivityRequest activityRequest = new()
            {
                InstanceId = _context.InstanceId, 
                QuoteId = _orchestration.QuoteId
            };
            await _context.CallActivityWithRetryAsync(nameof(StoreInstanceIdActivity), _retryOptions, activityRequest);
        }
        catch (Exception e)
        {
            await SendExceptionToServiceBus(e, "Call store instance id activity");
        }
    }
}