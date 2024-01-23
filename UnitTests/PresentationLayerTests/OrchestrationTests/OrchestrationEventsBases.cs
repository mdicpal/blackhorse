namespace UnitTests.PresentationLayerTests.OrchestrationTests;

using ApplicationLayer;
using AzureFunderCommonMessages.DotNet.Request;
using Moq;

public abstract class OrchestrationEventsBase : OrchestrationBase
{
    protected TaskCompletionSource TimerEventTask = null!;
    protected TaskCompletionSource<ApplicationRequest> AmendmentEventTask = null!;

    [SetUp]
    protected void SetupEvents()
    {
        // Use TaskCompletionSource to simulate the completion of the tasks.
        AmendmentEventTask = new TaskCompletionSource<ApplicationRequest>();
        TimerEventTask = new TaskCompletionSource();

        // Mock the WaitForExternalEvent methods to return the tasks from TaskCompletionSource.
        Context
            .Setup(c => c.WaitForExternalEvent<ApplicationRequest>(ExternalEvents.Amendment))
            .Returns(() => AmendmentEventTask.Task);
        Context
            .Setup(c => c.CreateTimer(It.IsAny<DateTime>(), It.IsAny<CancellationToken>()))
            .Returns(() => TimerEventTask.Task);
    }
}