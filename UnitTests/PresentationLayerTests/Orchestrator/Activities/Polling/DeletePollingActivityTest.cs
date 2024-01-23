namespace UnitTests.PresentationLayerTests.Orchestrator.Activities.Polling
{
    using ApplicationLayer.Handlers.Amendments.Interfaces;
    using ApplicationLayer.Handlers.Amendments.Models;
    using ApplicationLayer.Handlers.Polling.Interfaces;
    using Domain.Logger;
    using global::Orchestrator.Activities.Application;
    using global::Orchestrator.Activities.Polling;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class DeletePollingActivityTest
    {
        [Test]
        public async Task DeletePollingActivitySuccessTest()
        {
            var deletePollingHandlerMock = new Mock<IDeletePollingHandler>();
            var loggerMock = new Mock<ILoggerAdapter<DeletePollingActivity>>();
            string ApplapplicationId = "123";
            var deletePollingActivity = new DeletePollingActivity(deletePollingHandlerMock.Object, loggerMock.Object);
            await deletePollingActivity.Run(ApplapplicationId);
            deletePollingHandlerMock.Verify(handler => handler.RunAsync(ApplapplicationId), Times.Once);
        }
        [Test]
        public void DeletePollingActivityExceptionTest()
        {
            var deletePollingHandlerMock = new Mock<IDeletePollingHandler>();
            var loggerMock = new Mock<ILoggerAdapter<DeletePollingActivity>>();
            var deletePollingActivity = new DeletePollingActivity(deletePollingHandlerMock.Object, loggerMock.Object);
            deletePollingHandlerMock.Setup(handler => handler.RunAsync(It.IsAny<string>()))
                                   .Throws(new Exception());
            Assert.ThrowsAsync<Exception>(async () => await deletePollingActivity.Run(It.IsAny<string>()));
           
        }
    }
}
