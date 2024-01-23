namespace UnitTests.ApplicationLayerTests.Handlers.Amendments
{
    using ApplicationLayer.Handlers.Amendments;
    using Moq;
    using NUnit.Framework;
    using FunderApi;
    using ApplicationLayer.Handlers.Interfaces;
    using ApplicationLayer.Handlers.Amendments.Models;

    public class AmendSubmitActivityFailedResponseMapperTests
    {
        private Mock<ICommonResponseMapper> _commonResponseMapperMock = null!;
        private AmendSubmitActivityFailedResponseMapper _amendSubmitActivityFailedResponseMapperMock = null!;

        [SetUp] 
        public void SetUp()
        {
            _commonResponseMapperMock = new Mock<ICommonResponseMapper>();
            _amendSubmitActivityFailedResponseMapperMock = new AmendSubmitActivityFailedResponseMapper(_commonResponseMapperMock.Object);
        }
        [Test]
        public void AmendSubmitActivityFailedResponseMapperTest()
        {
            // Arrange
            int quoteId = 1;
            string customerId = "123";
            string proposalId = "456";
            var exception = new Exception("Error Message");

            // Act
            var result = _amendSubmitActivityFailedResponseMapperMock.Map(quoteId, customerId, proposalId, exception, It.IsAny<GenericErrorResponse>());

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result.Success, Is.True);
                Assert.That(result.CommonResponses, Is.Not.Null);
                Assert.That(result.CommonResponses, Has.Count.EqualTo(1));
                Assert.That(result, Is.Not.Null);
            });
        }
    }
}
