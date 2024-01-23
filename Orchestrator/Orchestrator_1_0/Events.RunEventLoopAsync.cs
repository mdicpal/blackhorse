namespace Orchestrator.Orchestrator_1_0;

using ApplicationLayer;
using ApplicationLayer.Models;
using AzureFunderCommonMessages.DotNet.Request;
using AzureFunderCommonMessages.DotNet.Types;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public partial class OrchestratorV1_0
{
    /**
     * <summary>
     * Once the application has been successfully submitted to the funder the event loop
     * will wait for any further events raised from Triggers (Service Bus Trigger / Timer Triggers)
     * </summary>
     */
    public async Task RunEventLoopAsync()
    {
        int ExpiryDays = 14; //TODO not here!
        using (var timeoutCts = new CancellationTokenSource())
        {
            Log($"Starting Event Loop for {_orchestration.QuoteId}");
            DateTime expiration = _context.CurrentUtcDateTime.AddDays(ExpiryDays);
            Task timeoutTask = _context.CreateTimer(expiration, timeoutCts.Token);

            List<Task> tasksToAwait = new();
            var amendmentEvent = _context.WaitForExternalEvent<ApplicationRequest>(ExternalEvents.Amendment);
            var funderUpdateEvent = _context.WaitForExternalEvent<FunderUpdate>(ExternalEvents.FunderUpdateEvent);
            tasksToAwait.Add(amendmentEvent);
            tasksToAwait.Add(funderUpdateEvent);

            bool exitLoop = false;
            do
            {
                Log($"Waiting for events for {_orchestration.QuoteId}");
                Task eventTriggered = await Task.WhenAny(tasksToAwait);
                tasksToAwait.Remove(eventTriggered);

                if (EventWasTriggered(funderUpdateEvent))
                {
                    FunderUpdate update = funderUpdateEvent.Result;
                    await HandleFunderUpdateEventAsync(update);
                    await CallUpsertPollingActivityAsync(update.FunderResponse);
                    funderUpdateEvent = _context.WaitForExternalEvent<FunderUpdate>(ExternalEvents.FunderUpdateEvent);
                    tasksToAwait.Add(funderUpdateEvent);
                }

                if (EventWasTriggered(amendmentEvent))
                {
                    ApplicationRequest update = amendmentEvent.Result;
                    await HandleAmendmentEventAsync(update);
                    amendmentEvent = _context.WaitForExternalEvent<ApplicationRequest>(ExternalEvents.Amendment);
                    tasksToAwait.Add(amendmentEvent);
                }

                if (_orchestration.ApplicationStatus is StatusResponseType.PaidOut or StatusResponseType.NTU)
                {
                    exitLoop = true;
                }

                HandleTimeoutTask(timeoutTask, exitLoop);
            } while (!exitLoop);
        }
    }
}