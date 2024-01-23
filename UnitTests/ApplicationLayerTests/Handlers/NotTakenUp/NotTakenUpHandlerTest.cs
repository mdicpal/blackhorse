namespace UnitTests.ApplicationLayerTests.Handlers.NotTakenUp
{
    using ApplicationLayer.Handlers.NotTakenUp.Interfaces;
    using ApplicationLayer.Handlers.NotTakenUp.Models;
    using ApplicationLayer.Handlers.NotTakenUp;
    using Domain.Logger;
    using FunderApi;
    using FunderService.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Castle.Core.Logging;
    using AzureFunderCommonMessages.DotNet.Response.SubResponses;
    using AzureFunderCommonMessages.DotNet.Response;
    using Orchestrator.Triggers;
    using AzureFunderCommonMessages.DotNet.Request;
    using Microsoft.Extensions.Logging;

    internal class NotTakenUpHandlerTest
    {
        private Mock<IFunderClient> _client;
        private Mock<INotTakenUpActivitySuccessResponseMapper> _activitySuccessResponseMapper;
        private Mock<INotTakenUpActivityFailedResponseMapper> _activityFailedResponseMapper;
        private Mock<ILogger<NotTakenUpHandler>> _loggerMock;
        private NotTakenUpHandler _notTakenUpHandler;
        [SetUp]
        public void SetUp()
        {
            _client = new Mock<IFunderClient>();
            _activitySuccessResponseMapper = new Mock<INotTakenUpActivitySuccessResponseMapper>();
            _activityFailedResponseMapper = new Mock<INotTakenUpActivityFailedResponseMapper>();
            _loggerMock = new Mock<ILogger<NotTakenUpHandler>>();
            _notTakenUpHandler = new NotTakenUpHandler(_client.Object, _activitySuccessResponseMapper.Object, _activityFailedResponseMapper.Object, _loggerMock.Object);
        }
        [Test]
        public async Task Run_SuccessfulRequest_ReturnsSuccessResponse()
        {
            int majorDealerId = Convert.ToInt32(Environment.GetEnvironmentVariable("x-lbg-major-dealerId"));
            int minorDealerId = Convert.ToInt32(Environment.GetEnvironmentVariable("x-lbg-minor-dealerId"));
            string idempotency = DateTime.Now.ToString("yyyymmddhhmmss");
            var notTakenUpActivityRequest = new NotTakenUpActivityRequest
            {
                ApplicationRequest = new ApplicationRequest()
                {
                    QuoteId = 123,
                },
                CustomerId = "285",
                ProposalId = "1",
                ApplicationId = 123,

            };
            Dictionary<string, object> newobject = new Dictionary<string, object>();
            newobject.Add("abcd", "abcds");
            var successResponse = new NotTakenUpActivityResponse()
            {
                ApplicationReference = new()
                {
                    CustomerId = 285,
                    ProposalId = 1
                },
                ApplicationStatus = AzureFunderCommonMessages.DotNet.Types.StatusResponseType.Accepted,
                Success = true,
                CommonResponses = {null,null}
            };
            NotTakenUpResponse funderResponse = new();
            _client.Setup(x => x.NotTakenUpAsync(majorDealerId,minorDealerId,idempotency,Convert.ToInt32(notTakenUpActivityRequest.CustomerId),Convert.ToInt32(notTakenUpActivityRequest.ProposalId))).ReturnsAsync(funderResponse);
            _activitySuccessResponseMapper.Setup(x => x.Map(notTakenUpActivityRequest.ApplicationRequest.QuoteId, notTakenUpActivityRequest.CustomerId, notTakenUpActivityRequest.ProposalId, funderResponse)).Returns(successResponse);
            var response = await _notTakenUpHandler.Run(notTakenUpActivityRequest);
            Assert.That(response, Is.EqualTo(successResponse));
        }

        [Test]
        public async Task Run_FailedRequest_ReturnsFailedResponse()
        {
            int majorDealerId = Convert.ToInt32(Environment.GetEnvironmentVariable("x-lbg-major-dealerId"));
            int minorDealerId = Convert.ToInt32(Environment.GetEnvironmentVariable("x-lbg-minor-dealerId"));
            string idempotency = DateTime.Now.ToString("yyyymmddhhmmss");
            var notTakenUpActivityRequest = new NotTakenUpActivityRequest
            {
                ApplicationRequest = new ApplicationRequest()
                {
                    QuoteId = 123,
                },
                CustomerId = "285",
                ProposalId = "1",
                ApplicationId = 123,

            };
            var FailedResponse = new NotTakenUpActivityResponse()
            {
                ApplicationReference = new()
                {
                    CustomerId = 285,
                    ProposalId = 1
                },
                ApplicationStatus = AzureFunderCommonMessages.DotNet.Types.StatusResponseType.Cancelled,
                Success = true,
                CommonResponses = { null, null }
            };
            Exception exception = new Exception("Test exception message");
            _client.Setup(x => x.NotTakenUpAsync(majorDealerId,minorDealerId,idempotency,It.IsAny<int>(), It.IsAny<int>())).ThrowsAsync(exception);
            _activityFailedResponseMapper.Setup(x => x.Map(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<NotTakenUpResponse>(), It.IsAny<Exception>()))
                .Returns(FailedResponse);

            var result = await _notTakenUpHandler.Run(notTakenUpActivityRequest);

            Assert.That(result, Is.Not.Null);

        }
    }
}
