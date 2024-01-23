namespace UnitTests.ApplicationLayerTests.Handlers.NotTakenUp
{
    using ApplicationLayer.Handlers.Interfaces;
    using ApplicationLayer.Handlers.NotTakenUp.Interfaces;
    using ApplicationLayer.Handlers.NotTakenUp;
    using AzureFunderCommonMessages.DotNet.Response.SubResponses;
    using AzureFunderCommonMessages.DotNet.Response;
    using FunderApi;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ApplicationLayer.Models;

    internal class NotTakenUpActivitySuccessResponseMapperTest
    {
        private INotTakenUpActivitySuccessResponseMapper _SuccessResponseMapper = null!;
        private Mock<ICommonResponseMapper> _commonResponseMapperMock;
        private NotTakenUpResponse _takenUpResponse;
        private ApplicationReference _applicationReference;
        [SetUp]
        public void SetUp()
        {
            _commonResponseMapperMock = new Mock<ICommonResponseMapper>();
            _SuccessResponseMapper = new NotTakenUpActivitySuccessResponseMapper(_commonResponseMapperMock.Object);
            _applicationReference = new ApplicationReference();
            _takenUpResponse = new NotTakenUpResponse();
        }
        [Test]
        public void Map_Exception_ReturnsNotTakenUpActivityResponseWithErrors()
        {
            int quoteId = 123;
            string customerId = "123";
            string proposalId = "123";
            _commonResponseMapperMock.Setup(x => x.Map(It.IsAny<int>(), _applicationReference, It.IsAny<StatusResponse>(), It.IsAny<object>(), It.IsAny<object>()))
                .Returns(new CommonResponse<StatusResponse>());
            var result = _SuccessResponseMapper.Map(quoteId, customerId, proposalId, _takenUpResponse);
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Success, Is.True);
                Assert.That(result.CommonResponses, Is.Not.Null);
            });
        }
    }
}
