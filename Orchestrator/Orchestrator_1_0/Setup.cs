namespace Orchestrator.Orchestrator_1_0;

using ApplicationLayer.Models;
using AzureFunderCommonMessages.DotNet.Request;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;

public partial class OrchestratorV1_0
{
    /**
         * <summary>
         * Acts as a constructor, creating initial objects as passed through the trigger
         * </summary>
         */
    private void Setup(IDurableOrchestrationContext context)
    {
        _context = context;
        var request = context.GetInput<ApplicationRequest>();
        _orchestration = new Orchestration
        {
            ApplicationRequest = request,
            QuoteId = request.QuoteId
        };
    }
}