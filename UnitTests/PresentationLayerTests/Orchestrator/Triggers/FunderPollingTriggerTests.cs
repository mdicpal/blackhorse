namespace UnitTests.PresentationLayerTests.Orchestrator.Triggers;

using ApplicationLayer.Handlers.Polling.Interfaces;
using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using Domain.Logger;
using global::Orchestrator.Timers;
using global::Orchestrator.Triggers.Interfaces;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Timers;
using Microsoft.Extensions.Logging;

public class FunderPollingTriggerTests
{
    [Test]
    public void RunAsync_ExecutesTimerTrigger()
    {
        var timerMock = new TimerInfo(new DailySchedule(), new ScheduleStatus());
        var loggerMock = new Mock<ILogger<FunderPollingTrigger>>();
        var repository = new Mock<IInstanceToPollRepository>();
        repository.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<InstanceToPollDto>());
        var funderPollingTrigger = new FunderPollingTrigger(
            loggerMock.Object, repository.Object,
            new Mock<IPollingHandler>().Object,
            new Mock<IFunderUpdateEventTrigger>().Object
        );
        Assert.DoesNotThrowAsync(async () => await funderPollingTrigger.RunAsync(timerMock, null));
    }
}