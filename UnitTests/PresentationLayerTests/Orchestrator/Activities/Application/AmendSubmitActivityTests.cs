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

    public class AmendSubmitActivityTests
    {
        [Test]
        public async Task AmendSubmitActivityTest()
        {
            //Arrange
            var _amendSubmitActivityRequest = new AmendSubmitActivityRequest();
            var _expectedResponse = new AmendSubmitActivityResponse();
            var _applicationHandlerMock = new Mock<IAmendSubmitHandler>(MockBehavior.Strict);
            var _loggerMock = new Mock<ILoggerAdapter<AmendSubmitActivityRequest>>();
            var _amendSubmitActivity = new AmendSubmitActivity(_applicationHandlerMock.Object, _loggerMock.Object);

            _applicationHandlerMock.Setup(x => x.Run(_amendSubmitActivityRequest)).ReturnsAsync(_expectedResponse);

            // Act
            var response = await _amendSubmitActivity.Run(_amendSubmitActivityRequest);

            // Assert
            Assert.That(_expectedResponse, Is.EqualTo(response));
            _applicationHandlerMock.Verify(x => x.Run(_amendSubmitActivityRequest), Times.Once);
        }

        [Test]
        public void AmendSubmitActivityExceptionTest()
        {
            var _amendSubmitActivityRequest = new AmendSubmitActivityRequest()
            {
                ApplicationRequest=new()
                {
                    QuoteId=1,
                }
            };
            var _applicationHandlerMock = new Mock<IAmendSubmitHandler>(MockBehavior.Strict);
            var _loggerMock = new Mock<ILoggerAdapter<AmendSubmitActivityRequest>>();
            var _amendSubmitActivity = new AmendSubmitActivity(_applicationHandlerMock.Object, _loggerMock.Object);

            _applicationHandlerMock.Setup(client => client.Run(_amendSubmitActivityRequest)).ThrowsAsync(new Exception());

            Assert.ThrowsAsync<Exception>(async () => await _amendSubmitActivity.Run(_amendSubmitActivityRequest));
        }
    }
}
