namespace Orchestrator.Orchestrator_1_0;

using Activities;
using AzureFunderCommonMessages.DotNet.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

public partial class OrchestratorV1_0
{
    /**
         * <summary>
         * Iterates through a collection of CommonResponses
         * Sends each response to the service bus
         * </summary>
         */
    private async Task SendCommonMessagesToServiceBusAsync(IEnumerable<CommonResponse> commonResponses)
    {
        foreach (CommonResponse commonResponse in commonResponses)
        {
            await _context.CallActivityWithRetryAsync(nameof(SendToServiceBusActivity), _retryOptions, commonResponse);
        }
    }
}