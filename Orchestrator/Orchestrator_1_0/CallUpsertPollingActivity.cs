namespace Orchestrator.Orchestrator_1_0;

using Activities.Polling;
using ApplicationLayer.Handlers.Polling.Models;
using FunderApi;
using System;
using System.Threading.Tasks;

public partial class OrchestratorV1_0
{
    /**
     * <summary>
     * Call activity to add / update the proposal to the polling database
     * </summary>
     */
    private async Task CallUpsertPollingActivityAsync(Decision postback)
    {
        try
        {
            UpsertRequest request = new()
            {
                FunderResponse = postback,
                ApplicationId = _orchestration.ApplicationId,
                ProposalId = _orchestration.ApplicationReference.ProposalId,
                CustomerId = _orchestration.ApplicationReference.CustomerId,
                InstanceId = _context.InstanceId,
                QuoteId = _orchestration.QuoteId
            };
            await _context.CallActivityWithRetryAsync(nameof(UpsertPollingActivity), _retryOptions, request);
        }
        catch (Exception e)
        {
            await SendExceptionToServiceBus(e, "Call upsert polling activity");
        }
    }
}