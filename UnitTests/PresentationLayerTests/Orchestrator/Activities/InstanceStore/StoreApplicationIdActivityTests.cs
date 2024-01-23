namespace UnitTests.PresentationLayerTests.Orchestrator.Activities.InstanceStore;

using ApplicationLayer.Models.Activities.InstanceStore;
using Domain.Logger;
using global::Orchestrator.Activities;
using global::Orchestrator.Activities.InstanceStore;
using InstanceStoreAdapter.Interfaces;
using Microsoft.Extensions.Logging;

public class StoreApplicationIdActivityTests
{
    [Test]
    public async Task Run_SetsApplicationIdInInstanceStore()
    {
        // Arrange
        var quoteId = 12345;
        var instanceId = "ABCDEF";
        var applicationId = "APPID";
        var instanceStoreServiceAdapterMock = new Mock<IInstanceStoreServiceAdapter>(MockBehavior.Strict);
        var _logger = new Mock<ILoggerAdapter<StoreApplicationIdActivity>>();
        var storeApplicationIdActivity = new StoreApplicationIdActivity(instanceStoreServiceAdapterMock.Object, _logger.Object);

        instanceStoreServiceAdapterMock.Setup(x => x.SetApplicationIdAsync(quoteId, instanceId, applicationId)).Returns(Task.CompletedTask);

        var request = new StoreApplicationIdActivityRequest
        {
            QuoteId = quoteId,
            InstanceId = instanceId,
            ApplicationId = applicationId
        };

        // Act
        await storeApplicationIdActivity.Run(request);

        // Assert
        instanceStoreServiceAdapterMock.Verify(x => x.SetApplicationIdAsync(quoteId, instanceId, applicationId), Times.Once);
    }

    [Test]
    public Task ExceptionSetsApplicationIdInInstanceStoreTest()
    {
        // Arrange
        var quoteId = 12345;
        var instanceId = "ABCDEF";
        var applicationId = "APPID";
        var instanceStoreServiceAdapterMock = new Mock<IInstanceStoreServiceAdapter>(MockBehavior.Strict);
        var _logger = new Mock<ILoggerAdapter<StoreApplicationIdActivity>>();
        var storeApplicationIdActivity = new StoreApplicationIdActivity(instanceStoreServiceAdapterMock.Object, _logger.Object);

        instanceStoreServiceAdapterMock.Setup(x => x.SetApplicationIdAsync(quoteId, instanceId, applicationId)).ThrowsAsync(new Exception());

        var request = new StoreApplicationIdActivityRequest
        {
            QuoteId = quoteId,
            InstanceId = instanceId,
            ApplicationId = applicationId
        };

        // Assert
        Assert.ThrowsAsync<Exception>(async () => await storeApplicationIdActivity.Run(request));
        return Task.CompletedTask;
    }
}