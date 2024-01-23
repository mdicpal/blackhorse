namespace Orchestrator.Orchestrator_1_0;

using Activities.Application;
using ApplicationLayer.Handlers.MakeApplication.Models;
using System;
using System.Threading.Tasks;

public partial class OrchestratorV1_0
{
    /**
     * <summary>
     * Send initial application request to the funder
     * </summary>
     * <returns>
     * True: if the application was successfully received and accepted by the funder,
     * False: if the application was was refused by the funder or if an exception was raised
     * </returns>
     */
    private async Task<bool> CallMakeApplicationActivityAsync()
    {
        try
        {
            var request = new MakeApplicationActivityRequest()
            {
                ApplicationRequest = _orchestration.ApplicationRequest
            };
            var response = await _context.CallActivityWithRetryAsync<MakeApplicationActivityResponse>(nameof(MakeApplicationActivity), _retryOptions, request);
            _orchestration.ApplicationId = response.ApplicationId;

            await SendCommonMessagesToServiceBusAsync(response.CommonResponses);

            if (response.Success)
            {
                _orchestration.ApplicationReference = response.ApplicationReference;
            }
            
            return response.Success;
        }
        catch (Exception e)
        {
            await SendExceptionToServiceBus(e, "Call make application request activity");
            return false;
        }
    }
}