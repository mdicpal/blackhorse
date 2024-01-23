namespace Orchestrator.Orchestrator_1_0;

using Activities.Application;
using ApplicationLayer.Handlers.FunderUpdates.Models;
using ApplicationLayer.Models;
using System;
using System.Threading.Tasks;

public partial class OrchestratorV1_0
{
    /**
     * <summary>
     * Handle postback events raised
     * </summary>
     */
    private async Task HandleFunderUpdateEventAsync(FunderUpdate updateRequest)
    {
        try
        {
            Log("Handle postback event started");
            var request = new ApplicationStatusResponse()
            {
                StatusUpdate = updateRequest.FunderResponse,
                QuoteId = _orchestration.QuoteId,
                ApplicationReference = _orchestration.ApplicationReference
            };

            var response = await _context.CallActivityWithRetryAsync<FunderUpdateResponse>(nameof(FunderUpdateActivity), _retryOptions, request);

            await SendCommonMessagesToServiceBusAsync(response.CommonResponses);
            _orchestration.ApplicationStatus = response.ApplicationStatus;
        }
        catch (Exception e)
        {
            await SendExceptionToServiceBus(e, "Handle Status Update Event");
        }
    }
}