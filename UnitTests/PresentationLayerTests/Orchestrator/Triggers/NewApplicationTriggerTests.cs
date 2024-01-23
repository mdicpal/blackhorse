namespace UnitTests.PresentationLayerTests.Orchestrator.Triggers;

using AzureFunderCommonMessages.DotNet.Request;
using Domain.Logger;
using global::Orchestrator.Orchestrator_1_0;
using global::Orchestrator.Triggers;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;

public class NewApplicationTriggerTests
{
    [Test]
    public async Task RunAsync_StartsNewOrchestration()
    {

        var starterMock = new Mock<IDurableOrchestrationClient>();
        var request = new ApplicationRequest { QuoteId = 123 };
        var newApplicationTrigger = new NewApplicationTrigger(new Mock<ILoggerAdapter<NewApplicationTrigger>>().Object);
        await newApplicationTrigger.RunAsync(starterMock.Object, request);
        starterMock.Verify(x => x.StartNewAsync(nameof(OrchestratorV1_0), null, request), Times.Once);
    }   
}