namespace UnitTests.PresentationLayerTests.Orchestrator.Activities.Application
{
    using ApplicationLayer.Handlers.Amendments.Interfaces;
    using ApplicationLayer.Handlers.Amendments.Models;
    using ApplicationLayer.Handlers.FunderUpdates;
    using ApplicationLayer.Handlers.FunderUpdates.Interfaces;
    using ApplicationLayer.Handlers.FunderUpdates.Models;
    using ApplicationLayer.Handlers.Polling.Interfaces;
    using ApplicationLayer.Models;
    using AzureFunderCommonMessages.DotNet.Types;
    using Domain.Logger;
    using FunderApi;
    using global::Orchestrator.Activities.Application;
    using global::Orchestrator.Activities.Polling;
    using global::Orchestrator.Exceptions;
    using global::Orchestrator.Triggers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Threading.Tasks;

    internal class FunderUpdateActivityTest
    {
        [Test]
        public void FunderUpdateActivitySuccessTest()
        {
            var funderupdateHandlerMock = new Mock<IFunderUpdateHandler>();
           ApplicationStatusResponse response = new ApplicationStatusResponse()
           
            {
                StatusUpdate=new Decision()
                {
                    Decision_status=DecisionStatus.ACCEPTED,
                    Proposal_number="1233",
                },
                QuoteId=123
            };
          var funderupdateresponse =  funderupdateHandlerMock.Setup(x => x.Run(response)).Returns(new FunderUpdateResponse());
            Assert.That(funderupdateresponse,Is.Not.Null);
            
        }

        [Test]
        public void FunderUpdateActivityExceptionTest()
        {
            var funderupdateHandlerMock = new Mock<IFunderUpdateHandler>();
            var loggerMock = new Mock<ILoggerAdapter<FunderUpdateActivity>>();
            ApplicationStatusResponse reponse = new()
            {
                StatusUpdate = new Decision()
                {
                    Decision_status = DecisionStatus.ACCEPTED,
                    Proposal_number = "1233",
                },
                QuoteId = 123
            };

            var funderupdateActivity = new FunderUpdateActivity(loggerMock.Object, funderupdateHandlerMock.Object);
            funderupdateHandlerMock.Setup(x => x.Run(reponse)).Throws(new Exception());
            Assert.Throws<Exception>(() => funderupdateActivity.Run(reponse));           
        }
    }
}
