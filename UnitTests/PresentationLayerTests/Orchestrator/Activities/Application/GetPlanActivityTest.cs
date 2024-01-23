namespace UnitTests.PresentationLayerTests.Orchestrator.Activities.Application
{
    using ApplicationLayer.Handlers.Plans.Interfaces;
    using Domain.Logger;
    using FunderApi;
    using global::Orchestrator.Activities.Application;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;

    internal class GetPlanActivityTest
    {
        private Mock<IPlanHandler> _planhandler;
        private Mock<ILoggerAdapter<GetPlanActivity>> _loggerPlanActivity;
        private GetPlanActivity _getPlanActivity;
        [SetUp]
        public void SetUp()
        {
            _loggerPlanActivity = new Mock<ILoggerAdapter<GetPlanActivity>>();
            _planhandler = new Mock<IPlanHandler>();
            _getPlanActivity=new GetPlanActivity(_planhandler.Object, _loggerPlanActivity.Object);
        }
        [Test]
        public  void GetplanTest()
        {
            int Planid = 1;
            GetPlanResponse getPlanResponse = new GetPlanResponse()
            {
                Description="abcd",
                Plan="abcs",
                Product="bcdaa",
            };
            _planhandler.Setup(x => x.Run(Planid)).ReturnsAsync(getPlanResponse);
            var  result = _getPlanActivity.Run(Planid);
            Assert.That(result.Result,Is.EqualTo(getPlanResponse));
        }
        [Test]
        public void GetplanTestforException()
        {
            int Planid = 1;
            Exception exception = new Exception();
            _planhandler.Setup(x => x.Run(Planid)).ThrowsAsync(exception);
            Assert.ThrowsAsync<Exception>(async () => await _getPlanActivity.Run(Planid));          
        }

    }
}
