namespace UnitTests.PresentationLayerTests.Orchestrator.Activities.Application
{
    using ApplicationLayer.Handlers.NotTakenUp.Interfaces;
    using ApplicationLayer.Handlers.NotTakenUp.Models;
    using ApplicationLayer.Handlers.Plans.Interfaces;
    using Domain.Logger;
    using FunderApi;
    using AzureFunderCommonMessages.DotNet.Request;
    using global::Orchestrator.Activities.Application;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;

    internal class NotTakenUpActivityTest
    {
        private Mock<INotTakenUpHandler> _handler;
        private Mock<ILoggerAdapter<NotTakenUpActivity>> _loggerNotTakenupActvity;
        private NotTakenUpActivity _notTakenUpActivity;
        [SetUp]
        public void SetUp()
        {
            _loggerNotTakenupActvity = new Mock<ILoggerAdapter<NotTakenUpActivity>>();
            _handler = new Mock<INotTakenUpHandler>();
            _notTakenUpActivity = new NotTakenUpActivity(_handler.Object, _loggerNotTakenupActvity.Object);
        }
        [Test]
        public void NotTakenUpActiviyTest()
        {
            NotTakenUpActivityRequest request = new()
            {
                ApplicationRequest = new()
                {
                    QuoteId = 1
                },
                ProposalId="1",
                CustomerId="1",
                ApplicationId=1
            };
           NotTakenUpActivityResponse response = new();
           _handler.Setup(x => x.Run(request)).ReturnsAsync(response);
           var result = _notTakenUpActivity.Run(request);
           Assert.That(result.Result, Is.EqualTo(response));
        }
        [Test]
        public  void NotTakenUpActiviyTestforException()
        {
            NotTakenUpActivityRequest request = new ()
            {
                ApplicationRequest = new ()
                {
                    QuoteId = 1
                },
                ProposalId = "1",
                CustomerId = "1",
                ApplicationId = 1
            };
            Exception exception = new();
            _handler.Setup(x => x.Run(request)).ThrowsAsync(exception);
            Assert.ThrowsAsync<Exception>(async () => await _notTakenUpActivity.Run(request));
        }

    }
}
