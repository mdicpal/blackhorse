namespace UnitTests.PresentationLayerTests.Orchestrator.Activities.Application;

using ApplicationLayer.Handlers.MakeApplication.Interfaces;
using ApplicationLayer.Handlers.MakeApplication.Models;
using Domain.Logger;
using global::Orchestrator.Activities;
using global::Orchestrator.Activities.Application;
using Microsoft.Extensions.Logging;

public class MakeApplicationActivityTests
{
    [Test]
    public async Task Run_DelegatesToMakeApplicationHandler()
    {
        // Arrange
        var makeApplicationActivityRequest = new MakeApplicationActivityRequest();
        var expectedResponse = new MakeApplicationActivityResponse();
        var _logger = new Mock<ILoggerAdapter<MakeApplicationActivity>>();
        var applicationHandlerMock = new Mock<IMakeApplicationHandler>(MockBehavior.Strict);
        var makeApplicationActivity = new MakeApplicationActivity(applicationHandlerMock.Object, _logger.Object);

        applicationHandlerMock.Setup(x => x.Run(makeApplicationActivityRequest)).ReturnsAsync(expectedResponse);

        // Act
        var response = await makeApplicationActivity.Run(makeApplicationActivityRequest);

        // Assert
        Assert.That(expectedResponse, Is.EqualTo(response));
        applicationHandlerMock.Verify(x => x.Run(makeApplicationActivityRequest), Times.Once);
    }

    [Test]
    public Task ExceptionMakeApplicationActivityTest()
    {
        // Arrange
        var makeApplicationActivityRequest = new MakeApplicationActivityRequest()
        {
            ApplicationRequest=new()
            {
                QuoteId = 1
            }
        };
        var expectedResponse = new MakeApplicationActivityResponse();
        var _logger = new Mock<ILoggerAdapter<MakeApplicationActivity>>();
        var applicationHandlerMock = new Mock<IMakeApplicationHandler>(MockBehavior.Strict);
        var makeApplicationActivity = new MakeApplicationActivity(applicationHandlerMock.Object, _logger.Object);

        applicationHandlerMock.Setup(x => x.Run(makeApplicationActivityRequest)).Throws(new Exception());

        // Assert
        Assert.ThrowsAsync<Exception>(async () => await makeApplicationActivity.Run(makeApplicationActivityRequest));
        return Task.CompletedTask;
    }
}