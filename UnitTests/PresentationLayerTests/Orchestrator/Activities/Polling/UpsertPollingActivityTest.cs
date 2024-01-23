namespace UnitTests.PresentationLayerTests.Orchestrator.Activities.Polling
{
    using ApplicationLayer.Handlers.Polling.Interfaces;
    using ApplicationLayer.Handlers.Polling.Models;
    using Domain.Logger;
    using global::Orchestrator.Activities.Polling;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class UpsertPollingActivityTest
    {
        [Test]
        public async Task UpsertPollingActivitySuccessTest()
        {
            var upsertPollingHandlerMock = new Mock<IUpsertPollingHandler>();
            var loggerMock = new Mock<ILoggerAdapter<UpsertPollingActivity>>();
            UpsertRequest upsertRequest = new UpsertRequest()
            {
                ApplicationId = "123",
            };
            var upsertPollingActivity = new UpsertPollingActivity(upsertPollingHandlerMock.Object, loggerMock.Object);
            await upsertPollingActivity.Run(upsertRequest);
            upsertPollingHandlerMock.Verify(handler => handler.RunAsync(upsertRequest), Times.Once);
        }
        [Test]
        public void UpsertPollingActivityExceptionTest()
        {
            var upsertPollingHandlerMock = new Mock<IUpsertPollingHandler>();
            var loggerMock = new Mock<ILoggerAdapter<UpsertPollingActivity>>();
            UpsertRequest upsertRequest = new UpsertRequest()
            {
                ApplicationId = "123",
            };
            var upsertPollingActivity = new UpsertPollingActivity(upsertPollingHandlerMock.Object, loggerMock.Object);
            //upsertPollingHandlerMock.Setup(handler => handler.RunAsync(upsertRequest).th
            //                       .Throws(new Exception());
            upsertPollingHandlerMock.Setup(x => x.RunAsync(upsertRequest)).Throws(new Exception());
            Assert.ThrowsAsync<Exception>(async () => await upsertPollingActivity.Run(upsertRequest));

        }
    }
}
