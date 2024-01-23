namespace UnitTests.PresentationLayerTests.OrchestrationTests;

using ApplicationLayer.Handlers.MakeApplication.Models;
using AzureFunderCommonMessages.DotNet.Response;
using global::Orchestrator.Activities;
using global::Orchestrator.Activities.Application;
using global::Orchestrator.Activities.InstanceStore;

public class OrchestrationRun : OrchestrationEventsBase
{
    [Test]
    public void StoreInstanceIdActivityExceptionIsCaught()
    {
        SetupActivityThrows(nameof(StoreInstanceIdActivity), new Exception());
        Assert.DoesNotThrowAsync(async () =>
        {
            await Orchestrator.RunOrchestrator(Context.Object);
            VerifyActivity(nameof(SendErrorToServiceBusActivity));
        });
    }

    [Test]
    public void InitialSendApplicationReturnsFalse()
    {
        CommonResponse commonResponse = new CommonResponse();
        SetupActivity(nameof(MakeApplicationActivity),
            new MakeApplicationActivityResponse
            {
                Success = false, 
                CommonResponses = { commonResponse }, 
                ApplicationId = "ApplicationId"
            });

        Assert.DoesNotThrowAsync(async () =>
            {
                await Orchestrator.RunOrchestrator(Context.Object);
                VerifyActivity(nameof(SendToServiceBusActivity), commonResponse);
            }
        );
    }

    [Test]
    public void InitialSendApplicationExceptionIsCaught()
    {
        SetupActivityThrows<MakeApplicationActivityResponse>(nameof(MakeApplicationActivity),
            new Exception());

        Assert.DoesNotThrowAsync(async () =>
            {
                await Orchestrator.RunOrchestrator(Context.Object);
                VerifyActivity(nameof(SendErrorToServiceBusActivity));
            }
        );
    }

    [Test]
    public void StoreApplicationIdStoredExceptionIsCaught()
    {
        ContextSetupPreEventLoop();
        SetupActivityThrows(nameof(StoreApplicationIdActivity), new Exception());
        Assert.DoesNotThrowAsync(async () =>
        {
            TimerEventTask.SetResult();
            await Orchestrator.RunOrchestrator(Context.Object);
            VerifyActivity(nameof(SendToServiceBusActivity));
            VerifyActivity(nameof(StoreApplicationIdActivity));
        });
    }
}