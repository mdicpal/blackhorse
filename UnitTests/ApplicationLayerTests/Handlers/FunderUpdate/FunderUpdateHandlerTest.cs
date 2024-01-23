namespace UnitTests.ApplicationLayerTests.Handlers.FunderUpdate
{
    using ApplicationLayer.Handlers.FunderUpdates;
    using ApplicationLayer.Handlers.FunderUpdates.Interfaces;
    using ApplicationLayer.Handlers.FunderUpdates.Models;
    using AzureFunderCommonMessages.DotNet.Types;
    using Domain.Logger;
    using FunderApi;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class FunderUpdateHandlerTest
    {
        private Mock<ILogger<FunderUpdateHandler>> _loggerMock;
        private Mock<IFunderUpdateSuccessResponseMapper> _successResponseMapper;
        private FunderUpdateHandler _handler;
        [SetUp]
        public void Setup()
        {
            _loggerMock = new Mock<ILogger<FunderUpdateHandler>>();
            _successResponseMapper = new Mock<IFunderUpdateSuccessResponseMapper>();
            _handler = new FunderUpdateHandler(_loggerMock.Object, _successResponseMapper.Object);
        }
        [Test]
        public void RunTest()
        {
            var applicationStatusResponse = new ApplicationStatusResponse
            {
                QuoteId = 123,
                StatusUpdate = new()
                {
                    Decision_status = DecisionStatus.ACCEPTED,
                    Condition = new List<string> { "Condition1", "Condition2" }
                }
            };
            var expectedMappedResponse = new FunderUpdateResponse();
            _successResponseMapper.Setup(x => x.Map(It.IsAny<ApplicationStatusResponse>(), It.IsAny<StatusResponseType>(), It.IsAny<List<string>>()))
                .Returns(expectedMappedResponse);
            var result = _handler.Run(applicationStatusResponse);            
            Assert.That(result,Is.EqualTo(expectedMappedResponse));
        }
    }

}
