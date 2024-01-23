namespace UnitTests.ApplicationLayerTests.Handlers.PlanTest
{
    using ApplicationLayer.Handlers.Plans;
    using Domain.Logger;
    using FunderApi;
    using FunderService.Interfaces;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class PlanHandlerTest
    {
        private Mock<IFunderClient> _client;
        private Mock<ILogger<PlanHandler>> _loggerMock;
        private PlanHandler _planhandler;
        [SetUp]
        public void SetUp()
        {
            _client = new Mock<IFunderClient>();
            _loggerMock = new Mock<ILogger<PlanHandler>>();
            _planhandler = new PlanHandler(_client.Object, _loggerMock.Object);
        }
        [Test]
        public void SuccesresposnseAsync()
        {
            int majorDealerId = Convert.ToInt32(Environment.GetEnvironmentVariable("x-lbg-major-dealerId"));
            int minorDealerId = Convert.ToInt32(Environment.GetEnvironmentVariable("x-lbg-minor-dealerId"));
            int planid = 123;
            GetPlanResponse getPlanResponse = new GetPlanResponse()
            {
                Plan = "abcd",
                Description = "sucees reponse",
                Product = "Audi",Campaign=null
            };
            _client.Setup(x => x.GetPlansAsync(majorDealerId,minorDealerId,planid)).ReturnsAsync(getPlanResponse);
            var response = _planhandler.Run(planid);
            Assert.That(response, Is.Not.Null);
        }
        [Test]
        public void ExceptionresposnseAsync()
        {
            int majorDealerId = Convert.ToInt32(Environment.GetEnvironmentVariable("x-lbg-major-dealerId"));
            int minorDealerId = Convert.ToInt32(Environment.GetEnvironmentVariable("x-lbg-minor-dealerId"));
            int planid = 123;          
            _client.Setup(x => x.GetPlansAsync(majorDealerId,minorDealerId,planid)).ThrowsAsync(new Exception());
            var response = _planhandler.Run(planid);
            Assert.That(response, Is.Not.Null);
        }

    }
}
