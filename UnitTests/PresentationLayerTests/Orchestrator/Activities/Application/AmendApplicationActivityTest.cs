namespace UnitTests.PresentationLayerTests.Orchestrator.Activities.Application
{
    using ApplicationLayer.Handlers.Amendments;
    using ApplicationLayer.Handlers.Amendments.Interfaces;
    using ApplicationLayer.Handlers.Amendments.Models;
    using ApplicationLayer.Handlers.MakeApplication.Interfaces;
    using ApplicationLayer.Handlers.MakeApplication.Models;
    using Domain.Logger;
    using global::Orchestrator.Activities.Application;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AmendApplicationActivityTest
    {
        [Test]
        public async Task AmendSubmitActivityTest()
        {
            //Arrange
            var _amendApplicationActivityRequest = new AmendApplicationActivityRequest();
            var _expectedResponse = new AmendApplicationActivityResponse();
            var _applicationHandlerMock = new Mock<IAmendApplicationHandler>(MockBehavior.Strict);
            var _loggerMock = new Mock<ILoggerAdapter<AmendApplicationActivity>>();
            var _amendApllicationActivity = new AmendApplicationActivity(_applicationHandlerMock.Object, _loggerMock.Object);

            _applicationHandlerMock.Setup(x => x.Run(_amendApplicationActivityRequest)).ReturnsAsync(_expectedResponse);

            // Act
            var response = await _amendApllicationActivity.Run(_amendApplicationActivityRequest);

            // Assert
            Assert.That(_expectedResponse, Is.EqualTo(response));
            _applicationHandlerMock.Verify(x => x.Run(_amendApplicationActivityRequest), Times.Once);
        }

        [Test]
        public void AmendSubmitActivityExceptionTest()
        {
            var _amendApplicationActivityRequest = new AmendApplicationActivityRequest()
            {
                ApplicationRequest = new()
                {
                    QuoteId=1
                }
            };

            var _applicationHandlerMock = new Mock<IAmendApplicationHandler>(MockBehavior.Strict);
            var _loggerMock = new Mock<ILoggerAdapter<AmendApplicationActivity>>();
            var _amendApllicationActivity = new AmendApplicationActivity(_applicationHandlerMock.Object, _loggerMock.Object);

            _applicationHandlerMock.Setup(client => client.Run(_amendApplicationActivityRequest)).ThrowsAsync(new Exception());

            Assert.ThrowsAsync<Exception>(async () => await _amendApllicationActivity.Run(_amendApplicationActivityRequest));
        }
    }
}
