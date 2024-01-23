namespace UnitTests.PresentationLayerTests.OrchestrationTests.EventTests;

public class TimerTests : OrchestrationEventsBase
{
    [Test]
    public void TimerTriggerTest()
    {
        Context.Setup(c => c.CurrentUtcDateTime).Returns(DateTime.UtcNow);
        ContextSetupPreEventLoop();
        Assert.DoesNotThrowAsync(async () =>
        {
            TimerEventTask.SetResult();
            await Orchestrator.RunOrchestrator(Context.Object);
        });
    }
}