namespace UnitTests.PresentationLayerTests.Orchestrator.Triggers;

using ApplicationLayer.Models;
using Azure.Messaging.ServiceBus;
using AzureFunderCommonMessages.DotNet.Extensions;
using AzureFunderCommonMessages.DotNet.Request;
using AzureFunderCommonMessages.DotNet.Types;
using Domain.Logger;
using global::Orchestrator.Exceptions;
using global::Orchestrator.Triggers;
using global::Orchestrator.Triggers.Interfaces;
using InstanceStoreAdapter.Interfaces;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;

public class MakeApplicationTriggerTests
{
    private Mock<ILoggerAdapter<MakeApplicationTrigger>> _loggerMock = null!;
    private Mock<IInstanceStoreServiceAdapter> _instanceStoreAdapterMock = null!;
    private Mock<IRaiseAmendmentTrigger> _raiseAmendmentTriggerMock = null!;
    private Mock<INewApplicationTrigger> _newApplicationTriggerMock = null!;
    private MakeApplicationTrigger _makeApplicationTrigger = null!;
    private ApplicationRequest _applicationRequest = null!;
    private ServiceBusReceivedMessage _serviceBusMessage;

    [SetUp]
    public void Setup()
    {
        _loggerMock = new Mock<ILoggerAdapter<MakeApplicationTrigger>>();
        _instanceStoreAdapterMock = new Mock<IInstanceStoreServiceAdapter>();
        _raiseAmendmentTriggerMock = new Mock<IRaiseAmendmentTrigger>();
        _newApplicationTriggerMock = new Mock<INewApplicationTrigger>();

        _makeApplicationTrigger = new MakeApplicationTrigger(
            _loggerMock.Object,
            _instanceStoreAdapterMock.Object,
            _raiseAmendmentTriggerMock.Object,
            _newApplicationTriggerMock.Object
        );
        
        _applicationRequest = new ApplicationRequest()
        {
            Version = 1,
            FunderCode = "OODLEV2",
            QuoteId = 1,
            Data = new(),
            RequestType = RequestType.MakeApplication
        };

        string body = _applicationRequest.ToJson();
            
        _serviceBusMessage = ServiceBusModelFactory.ServiceBusReceivedMessage(properties: new Dictionary<string, object>(), body: new BinaryData(body));
    }

    [Test]
    public async Task RunAsync_ExistingInstanceInProgress_RaisesAmendmentTrigger_ThrowsInvalidOrchestration()
    {
        var orchestrationClientMock = new Mock<IDurableOrchestrationClient>();
        var existingInstance = new Instance { Id = "existingInstanceId", Status = "running" };   
        _instanceStoreAdapterMock.Setup(x => x.GetAsync(_applicationRequest.QuoteId)).ReturnsAsync(existingInstance);
        _raiseAmendmentTriggerMock.Setup(x => x.RunAsync(orchestrationClientMock.Object, It.IsAny<ApplicationRequest>(), existingInstance.Id)).ThrowsAsync(new InvalidOrchestrationException());
        _newApplicationTriggerMock.Setup(x => x.RunAsync(orchestrationClientMock.Object, It.IsAny<ApplicationRequest>())).Returns(Task.CompletedTask);
        var orchestrationClient = orchestrationClientMock.Object;
        await _makeApplicationTrigger.RunAsync(_serviceBusMessage, orchestrationClient);
        Assert.Multiple(() =>
        {
            
            _instanceStoreAdapterMock.Verify(x => x.GetAsync(_applicationRequest.QuoteId), Times.Once);
            _raiseAmendmentTriggerMock.Verify(x => x.RunAsync(orchestrationClient, It.IsAny<ApplicationRequest>(), existingInstance.Id), Times.Once);
            _newApplicationTriggerMock.Verify(x => x.RunAsync(orchestrationClient, It.IsAny<ApplicationRequest>()), Times.Once);
        });
    }

    [Test]
    public async Task RunAsync_ExistingInstanceInProgress_RaisesAmendmentTrigger_ThrowsException()
    {
        var orchestrationClientMock = new Mock<IDurableOrchestrationClient>();
        var existingInstance = new Instance { Id = "existingInstanceId", Status = "running" };
        _instanceStoreAdapterMock.Setup(x => x.GetAsync(_applicationRequest.QuoteId)).ThrowsAsync(new Exception());
        var orchestrationClient = orchestrationClientMock.Object;
        await _makeApplicationTrigger.RunAsync(_serviceBusMessage, orchestrationClient);
        Assert.Multiple(() =>
        {
            
            _instanceStoreAdapterMock.Verify(x => x.GetAsync(_applicationRequest.QuoteId), Times.Once);
            _raiseAmendmentTriggerMock.Verify(x => x.RunAsync(orchestrationClient, It.IsAny<ApplicationRequest>(), existingInstance.Id), Times.Never);
            _newApplicationTriggerMock.Verify(x => x.RunAsync(orchestrationClient, It.IsAny<ApplicationRequest>()), Times.Never);
        });
    }

    [Test]
    public async Task RunAsync_ExistingInstanceInProgress_RaisesAmendmentTrigger()
    {
        var orchestrationClientMock = new Mock<IDurableOrchestrationClient>();
        var existingInstance = new Instance { Id = "existingInstanceId", Status = "running", ApplicationId = "A1", QuoteId = 1};
        _instanceStoreAdapterMock.Setup(x => x.GetAsync(_applicationRequest.QuoteId)).ReturnsAsync(existingInstance);
        _raiseAmendmentTriggerMock.Setup(x => x.RunAsync(orchestrationClientMock.Object, It.IsAny<ApplicationRequest>(), existingInstance.Id)).Returns(Task.CompletedTask);
        var orchestrationClient = orchestrationClientMock.Object;
        await _makeApplicationTrigger.RunAsync(_serviceBusMessage, orchestrationClient);
        Assert.Multiple(() =>
        {
            
            _instanceStoreAdapterMock.Verify(x => x.GetAsync(_applicationRequest.QuoteId), Times.Once);
            _raiseAmendmentTriggerMock.Verify(x => x.RunAsync(orchestrationClient, It.IsAny<ApplicationRequest>(), existingInstance.Id), Times.Once);
            _newApplicationTriggerMock.Verify(x => x.RunAsync(orchestrationClient, It.IsAny<ApplicationRequest>()), Times.Never);
        });
    }

    [Test]
    public async Task RunAsync_CompletedInstance_RaisesAmendmentTrigger()
    {
        var orchestrationClientMock = new Mock<IDurableOrchestrationClient>();
        var existingInstance = new Instance { Id = "existingInstanceId", Status = "completed" };
        _instanceStoreAdapterMock.Setup(x => x.GetAsync(_applicationRequest.QuoteId)).ReturnsAsync(existingInstance);
        _newApplicationTriggerMock.Setup(x => x.RunAsync(orchestrationClientMock.Object, It.IsAny<ApplicationRequest>())).Returns(Task.CompletedTask);
        var orchestrationClient = orchestrationClientMock.Object;
        await _makeApplicationTrigger.RunAsync(_serviceBusMessage, orchestrationClient);
        Assert.Multiple(() =>
        {
            
            _instanceStoreAdapterMock.Verify(x => x.GetAsync(_applicationRequest.QuoteId), Times.Once);
            _raiseAmendmentTriggerMock.Verify(x => x.RunAsync(orchestrationClient, It.IsAny<ApplicationRequest>(), existingInstance.Id), Times.Never);
            _newApplicationTriggerMock.Verify(x => x.RunAsync(orchestrationClient, It.IsAny<ApplicationRequest>()), Times.Once);
        });
    }

    [Test]
    public async Task RunAsync_NullInstance_RaisesAmendmentTrigger()
    {
        var orchestrationClientMock = new Mock<IDurableOrchestrationClient>();
        _newApplicationTriggerMock.Setup(x => x.RunAsync(orchestrationClientMock.Object, It.IsAny<ApplicationRequest>())).Returns(Task.CompletedTask);
        var orchestrationClient = orchestrationClientMock.Object;
        await _makeApplicationTrigger.RunAsync(_serviceBusMessage, orchestrationClient);
        Assert.Multiple(() =>
        {
            
            _instanceStoreAdapterMock.Verify(x => x.GetAsync(_applicationRequest.QuoteId), Times.Once);
            _raiseAmendmentTriggerMock.Verify(x => x.RunAsync(orchestrationClient, It.IsAny<ApplicationRequest>(), It.IsAny<string>()), Times.Never);
            _newApplicationTriggerMock.Verify(x => x.RunAsync(orchestrationClient, It.IsAny<ApplicationRequest>()), Times.Once);
        });
    }
}