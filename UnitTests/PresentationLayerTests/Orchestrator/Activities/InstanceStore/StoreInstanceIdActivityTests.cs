namespace UnitTests.PresentationLayerTests.Orchestrator.Activities.InstanceStore;

using ApplicationLayer.Models.Activities.InstanceStore;
using Domain.Logger;
using global::Orchestrator.Activities;
using global::Orchestrator.Activities.Application;
using global::Orchestrator.Activities.InstanceStore;
using InstanceStoreAdapter.Interfaces;
using Microsoft.Extensions.Logging;

public class StoreInstanceIdActivityTests
{
    [Test]
    public async Task Run_StoresInstanceIdInInstanceStore()
    {
        // Arrange
        var quoteId = 12345;
        var instanceId = "ABCDEF";
        var instanceStoreServiceAdapterMock = new Mock<IInstanceStoreServiceAdapter>(MockBehavior.Strict);
        var _logger = new Mock<ILoggerAdapter<StoreInstanceIdActivity>>();
        var storeInstanceIdActivity = new StoreInstanceIdActivity(instanceStoreServiceAdapterMock.Object, _logger.Object);

        instanceStoreServiceAdapterMock.Setup(x => x.CreateAsync(quoteId, instanceId)).Returns(Task.CompletedTask);

        var request = new StoreInstanceIdActivityRequest
        {
            QuoteId = quoteId,
            InstanceId = instanceId
        };

        // Act
        await storeInstanceIdActivity.Run(request);

        // Assert
        instanceStoreServiceAdapterMock.Verify(x => x.CreateAsync(quoteId, instanceId), Times.Once);
    }

    [Test]
    public Task ExceptiuonStoresInstanceIdInInstanceStoreTest()
    {
        // Arrange
        var quoteId = 12345;
        var instanceId = "ABCDEF";
        var instanceStoreServiceAdapterMock = new Mock<IInstanceStoreServiceAdapter>(MockBehavior.Strict);
        var _logger = new Mock<ILoggerAdapter<StoreInstanceIdActivity>>();
        var storeInstanceIdActivity = new StoreInstanceIdActivity(instanceStoreServiceAdapterMock.Object, _logger.Object);

        instanceStoreServiceAdapterMock.Setup(x => x.CreateAsync(quoteId, instanceId)).ThrowsAsync(new Exception());

        var request = new StoreInstanceIdActivityRequest
        {
            QuoteId = quoteId,
            InstanceId = instanceId
        };

        // Assert
        Assert.ThrowsAsync<Exception>(async () => await storeInstanceIdActivity.Run(request));
        return Task.CompletedTask;
    }
}