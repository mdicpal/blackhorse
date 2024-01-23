namespace Orchestrator.Orchestrator_1_0;

using Activities;
using ApplicationLayer.Models;
using System;
using System.Threading.Tasks;

public partial class OrchestratorV1_0
{
    /**
     * <summary>
     * Gets the message from the Exception and sends this to the service bus
     * </summary>
     */
    private async Task SendExceptionToServiceBus(Exception e, string method, string message = "Caught Exception")
    {
        Log(e, $"{method} - {message}");
        var request = new SendErrorToServiceBusActivityRequest
        {
            QuoteId = _orchestration.QuoteId,
            ApplicationReference = _orchestration.ApplicationReference,
            ErrorMessage = e.InnerException?.Message ?? e.Message
        };
        await _context.CallActivityWithRetryAsync(nameof(SendErrorToServiceBusActivity), _retryOptions, request);
    }
}