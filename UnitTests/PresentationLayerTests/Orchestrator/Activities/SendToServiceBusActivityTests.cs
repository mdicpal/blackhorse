namespace UnitTests.PresentationLayerTests.Orchestrator.Activities;

using Azure.Messaging.ServiceBus;
using AzureFunderCommonMessages.DotNet.Extensions;
using AzureFunderCommonMessages.DotNet.Response;
using Domain.Logger;
using global::Orchestrator.Activities;
using global::Orchestrator.Activities.InstanceStore;
using global::Orchestrator.Extensions;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

public class SendToServiceBusActivityTests
{
    [Test]
    public async Task ActivityFunction_AddsMessageToServiceBus()
    {
        // Arrange
        var commonResponse = new CommonResponse()
        {
            QuoteId = 1,
            FunderCode = "OODLEV2"
        };
        var serviceBusMock = new Mock<IAsyncCollector<ServiceBusMessage>>();
        var _logger = new Mock<ILoggerAdapter<SendToServiceBusActivity>>();
        var sendToServiceBusActivity = new SendToServiceBusActivity(_logger.Object);

        var expectedServiceBusMessage = new ServiceBusMessage(commonResponse.ToJson());
        // set up any additional properties or headers if required

        serviceBusMock
            .Setup(x => x.AddAsync(expectedServiceBusMessage, default))
            .Returns(Task.CompletedTask);

        // Act
        await sendToServiceBusActivity.ActivityFunction(commonResponse, serviceBusMock.Object);

        // Assert Tests
        serviceBusMock.Verify(x => x.AddAsync(
            It.Is<ServiceBusMessage>(s => 
                s.ApplicationProperties.ContainsKey("quoteId")
                && s.ApplicationProperties.ContainsKey("funderCode") 
                && s.ApplicationProperties.ContainsKey("requestType") 
            ), default), Times.Once);
    }
    [Test]
    public Task ExceptionSendToServiceBusActivityTest()
    {
        // Arrange
        var commonResponse = new CommonResponse()
        {
            QuoteId = 1,
            FunderCode = "OODLEV2",
        };
        var serviceBusMock = new Mock<IAsyncCollector<ServiceBusMessage>>();
        var _logger = new Mock<ILoggerAdapter<SendToServiceBusActivity>>();
        var sendToServiceBusActivity = new SendToServiceBusActivity(_logger.Object);

        var expectedServiceBusMessage = new ServiceBusMessage(commonResponse.ToJson());
        expectedServiceBusMessage.SetApplicationPropertiesFromMessage(commonResponse);
        // set up any additional properties or headers if required
        serviceBusMock
            .Setup(x => x.AddAsync(It.IsAny<ServiceBusMessage>(), default))
            .Throws(new Exception());

        // Assert Tests
        Assert.ThrowsAsync<Exception>(async () => await sendToServiceBusActivity.ActivityFunction(commonResponse, serviceBusMock.Object));

        return Task.CompletedTask;
    }
}