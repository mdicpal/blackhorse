namespace UnitTests.ApplicationLayerTests.Handlers.Amendments
{
    using ApplicationLayer.Handlers.Amendments;
    using Moq;
    using NUnit.Framework;
    using FunderApi;
    using ApplicationLayer.Handlers.Interfaces;

    public class AmendSubmitSuccessResponseMapperTests
    {
        private Mock<ICommonResponseMapper> _commonResponseMapperMock = null!;
        private AmendSubmitSuccessResponseMapper _amendSubmitSuccessResponseMapperMock = null!;

        [SetUp] 
        public void SetUp()
        {
            _commonResponseMapperMock = new Mock<ICommonResponseMapper>();

            _amendSubmitSuccessResponseMapperMock = new AmendSubmitSuccessResponseMapper(_commonResponseMapperMock.Object);
        }

        [Test]
        public void AmendSubmitSuccessResponseMapperTest()
        {
            // Arrange
            int quoteId = 1;
            string customerId = "123";
            string proposalId = "456";
            var funderResponse = new PostSubmitResponse();

            // Act
            var result = _amendSubmitSuccessResponseMapperMock.Map(quoteId, customerId, proposalId, funderResponse);

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
