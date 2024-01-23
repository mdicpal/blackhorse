namespace Orchestrator.Orchestrator_1_0;

using Activities.InstanceStore;
using ApplicationLayer.Models.Activities.InstanceStore;
using System.Threading.Tasks;

public partial class OrchestratorV1_0
{
    /**
         * <summary>
         * Stores the application id generated by the funder,
         * this is the funders reference variable for our QuoteId
         * </summary>
         */
    private async Task CallStoreApplicationIdActivityAsync()
    {
        var request = new StoreApplicationIdActivityRequest
        {
            ApplicationId = _orchestration.ApplicationId,
            InstanceId = _context.InstanceId,
            QuoteId = _orchestration.QuoteId
        };
        await _context.CallActivityWithRetryAsync(nameof(StoreApplicationIdActivity), _retryOptions, request);
    }
}