namespace UnitTests.PresentationLayerTests.Orchestrator.Triggers;

using ApplicationLayer;
using AzureFunderCommonMessages.DotNet.Request;
using Domain.Logger;
using global::Orchestrator.Exceptions;
using global::Orchestrator.Triggers;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;

public class MakeAmendmentTriggerTests
{
    [Test]
    public async Task RunAsync_RaiseAmendment()
    {
        var starterMock = new Mock<IDurableOrchestrationClient>();
        var request = new ApplicationRequest { QuoteId = 123 };
        const string instanceId = "instance-id";

        var newApplicationTrigger = new RaiseAmendmentTrigger(new Mock<ILoggerAdapter<RaiseAmendmentTrigger>>().Object);
       await newApplicationTrigger.RunAsync(starterMock.Object, request, instanceId);
        starterMock.Verify(x => x.RaiseEventAsync(instanceId, ExternalEvents.Amendment, request), Times.Once);
    }
        
    [Test]
    public void RunAsync_RaiseAmendmentThrowsException()
    {
        var starterMock = new Mock<IDurableOrchestrationClient>();
        var request = new ApplicationRequest { QuoteId = 123 };
        const string instanceId = "instance-id";
        starterMock.Setup(x => x.RaiseEventAsync(instanceId, ExternalEvents.Amendment, request)).ThrowsAsync(new Exception());
        var newApplicationTrigger = new RaiseAmendmentTrigger(new Mock<ILoggerAdapter<RaiseAmendmentTrigger>>().Object);
        Assert.ThrowsAsync<InvalidOrchestrationException>(async () => await newApplicationTrigger.RunAsync(starterMock.Object, request, instanceId));
        starterMock.Verify(x => x.RaiseEventAsync(instanceId, ExternalEvents.Amendment, request), Times.Once);
    }   
}