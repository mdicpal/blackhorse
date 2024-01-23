namespace Orchestrator.Orchestrator_1_0;

using Activities.Polling;
using System;
using System.Threading.Tasks;

public partial class OrchestratorV1_0
{
    /**
     * <summary>
     * Call activity to add / update the proposal to the polling database
     * </summary>
     */
    private async Task CallDeletePollingActivityAsync()
    {
        try
        {
            await _context.CallActivityWithRetryAsync(nameof(DeletePollingActivity), _retryOptions, _orchestration.ApplicationId);
        }
        catch (Exception e)
        {
            await SendExceptionToServiceBus(e, "call delete polling activity");
        }
    }
}