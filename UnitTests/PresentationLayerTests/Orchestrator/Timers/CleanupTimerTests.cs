namespace UnitTests.PresentationLayerTests.Orchestrator.Timers
{
    using Azure.Messaging.ServiceBus;
    using AzureFunderCommonMessages.DotNet.Response;
    using Domain.Logger;
    using DurableTask.Core;
    using global::Orchestrator.Activities;
    using global::Orchestrator.Timers;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.DurableTask;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CleanupTimerTests
    {
        [Test]
        public async Task CleanupTimerTest()
        {
            // Arrange
            var orchestrationClientMock = new Mock<IDurableOrchestrationClient>();
            var loggerMock = new Mock<ILogger<CleanupTimer>>();
            var cleanupTimer = new CleanupTimer(loggerMock.Object);

            orchestrationClientMock
                .Setup(x => x.PurgeInstanceHistoryAsync(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<List<OrchestrationStatus>>()))
                .ReturnsAsync(new PurgeHistoryResult(1));

            // Act
            await cleanupTimer.Run(It.IsAny<TimerInfo>(), orchestrationClientMock.Object, loggerMock.Object);

            // Assert
            orchestrationClientMock.Verify(
                x => x.PurgeInstanceHistoryAsync(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<List<OrchestrationStatus>>()),
                Times.Once);
        }

        [Test]
        public Task ExceptionCleanupTimerTest()
        {
            // Arrange
            var orchestrationClientMock = new Mock<IDurableOrchestrationClient>();
            var loggerMock = new Mock<ILogger<CleanupTimer>>();
            var cleanupTimer = new CleanupTimer(loggerMock.Object);

            orchestrationClientMock
                .Setup(x => x.PurgeInstanceHistoryAsync(It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<List<OrchestrationStatus>>()))
                .Throws(new Exception());

            // Assert
            Assert.ThrowsAsync<Exception>(async () => await cleanupTimer.Run(It.IsAny<TimerInfo>(), orchestrationClientMock.Object, loggerMock.Object));

            return Task.CompletedTask;
        }
    }
}
