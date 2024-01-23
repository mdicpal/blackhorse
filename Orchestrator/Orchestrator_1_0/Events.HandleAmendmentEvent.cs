namespace Orchestrator.Orchestrator_1_0;

using Activities.Application;
using ApplicationLayer.Handlers.Amendments.Models;
using AzureFunderCommonMessages.DotNet.Request;
using System;
using System.Threading.Tasks;

public partial class OrchestratorV1_0
{
    /**
     * <summary>
     * Handle amendment events raised
     * </summary>
     */
    private async Task HandleAmendmentEventAsync(ApplicationRequest updateRequest)
    {
        try
        {
            Log("Handle postback event started");
            var request = new AmendApplicationActivityRequest()
            {
                ApplicationRequest = updateRequest,
                ApplicationReference = _orchestration.ApplicationReference
            };

            var response = await _context.CallActivityWithRetryAsync<AmendApplicationActivityResponse>(nameof(AmendApplicationActivity), _retryOptions, request);

            await SendCommonMessagesToServiceBusAsync(response.CommonResponses);
            if (response.Success)
            {
                _orchestration.ApplicationStatus = response.ApplicationStatus;
            }
        }
        catch (Exception e)
        {
            await SendExceptionToServiceBus(e, "Handle Status Update Event");
        }
    }
}