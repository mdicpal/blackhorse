namespace UnitTests.ApplicationLayerTests.Handlers.NotTakenUp
{
    using ApplicationLayer.Handlers.Interfaces;
    using ApplicationLayer.Handlers.NotTakenUp;
    using AzureFunderCommonMessages.DotNet.Response.SubResponses;
    using AzureFunderCommonMessages.DotNet.Response;
    using FunderApi;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ApplicationLayer.Handlers.MakeApplication.Interfaces;
    using ApplicationLayer.Handlers.NotTakenUp.Interfaces;
    using Grpc.Core.Logging;
    using ApplicationLayer.Handlers;
    using ApplicationLayer.Models;
    using AzureFunderCommonMessages.DotNet.Interfaces.Response;

    internal class NotTakenUpActivityFailedResponseMapperTest
    {
        private INotTakenUpActivityFailedResponseMapper _failedResponseMapper = null!;
        private Mock<ICommonResponseMapper> _commonResponseMapperMock;
        private NotTakenUpResponse _takenUpResponse;
        private ApplicationReference _applicationReference;
        [SetUp]
        public void SetUp()
        {
            _commonResponseMapperMock = new Mock<ICommonResponseMapper>();
            _failedResponseMapper = new NotTakenUpActivityFailedResponseMapper(_commonResponseMapperMock.Object);
            _applicationReference = new ApplicationReference();
            _takenUpResponse = new NotTakenUpResponse();
        }
        [Test]
        public void Map_Exception_ReturnsNotTakenUpActivityResponseWithErrors()
        {
            var quoteId = 123;
            var customerId = "testCustomerId";
            var proposalId = "testProposalId";
            Exception exception = new Exception("Test Exception");
            _commonResponseMapperMock.Setup(x => x.Map(It.IsAny<int>(), _applicationReference, It.IsAny<FunderErrors>(), It.IsAny<object>(), It.IsAny<object>()))
                .Returns(new CommonResponse<FunderErrors>());
            var result = _failedResponseMapper.Map(quoteId, customerId, proposalId, _takenUpResponse, exception);
           
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Success, Is.True);
                Assert.That(result.CommonResponses, Is.Not.Null);
            });
        }
    }
}
