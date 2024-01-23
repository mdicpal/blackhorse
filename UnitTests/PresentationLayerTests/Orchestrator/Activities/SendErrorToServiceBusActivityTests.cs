namespace UnitTests.PresentationLayerTests.Orchestrator.Activities;

using ApplicationLayer.Handlers.Amendments.Models;
using ApplicationLayer.Handlers.Interfaces;
using ApplicationLayer.Models;
using Azure.Messaging.ServiceBus;
using AzureFunderCommonMessages.DotNet.Request;
using AzureFunderCommonMessages.DotNet.Response;
using AzureFunderCommonMessages.DotNet.Response.SubResponses;
using Domain.Logger;
using global::Orchestrator.Activities;
using global::Orchestrator.Activities.InstanceStore;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

public class SendErrorToServiceBusActivityTests
{
    [Test]
    public async Task ActivityFunction_AddsMessageToServiceBus()
    {
        ApplicationReference applicationReference = new ApplicationReference();
        SendErrorToServiceBusActivityRequest request = new()
        {
            QuoteId = 1,
            ApplicationReference = applicationReference,
            ErrorMessage = "ErrorMessage"
        };
            
        var serviceBusMock = new Mock<IAsyncCollector<ServiceBusMessage>>();
        Mock<ICommonResponseMapper> commonResponseMapperMock = new Mock<ICommonResponseMapper>();
        var _logger = new Mock<ILoggerAdapter<SendErrorToServiceBusActivity>>();
        var sendErrorToServiceBusActivity = new SendErrorToServiceBusActivity(commonResponseMapperMock.Object, _logger.Object);

        commonResponseMapperMock
            .Setup(x => x.Map(request.QuoteId, applicationReference, It.IsAny<ErrorResponse>(), null, null))
            .Returns(new CommonResponse<ErrorResponse>() { QuoteId = request.QuoteId, FunderCode = "OODLEV2" });

        // Act
        await sendErrorToServiceBusActivity.ActivityFunction(request, serviceBusMock.Object);

        // Assert
        serviceBusMock.Verify(x => x.AddAsync(
            It.Is<ServiceBusMessage>(s => 
                s.ApplicationProperties.ContainsKey("quoteId")
                && s.ApplicationProperties.ContainsKey("funderCode") 
                && s.ApplicationProperties.ContainsKey("requestType") 
            ), default), Times.Once);
    }

    [Test]
    public Task ExceptionAddsMessageToServiceBusTest()
    {
        // Arrange
        ApplicationReference applicationReference = new ApplicationReference();
        SendErrorToServiceBusActivityRequest request = new()
        {
            QuoteId = 1,
            ApplicationReference = applicationReference,
            ErrorMessage = "ErrorMessage"
        };
        var serviceBusMock = new Mock<IAsyncCollector<ServiceBusMessage>>();
        Mock<ICommonResponseMapper> commonResponseMapperMock = new Mock<ICommonResponseMapper>();
        var _logger = new Mock<ILoggerAdapter<SendErrorToServiceBusActivity>>();
        var sendErrorToServiceBusActivity = new SendErrorToServiceBusActivity(commonResponseMapperMock.Object, _logger.Object);

        commonResponseMapperMock
            .Setup(x => x.Map(request.QuoteId, applicationReference, It.IsAny<ErrorResponse>(), null, null))
           .Throws(new Exception());       
        Assert.ThrowsAsync<Exception>(async () => await sendErrorToServiceBusActivity.ActivityFunction(request, serviceBusMock.Object));
        return Task.CompletedTask;
    }
}