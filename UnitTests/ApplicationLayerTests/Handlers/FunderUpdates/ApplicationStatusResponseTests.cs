namespace UnitTests.ApplicationLayerTests.Handlers.FunderUpdates
{
    using ApplicationLayer.Handlers.FunderUpdates.Models;
    using ApplicationLayer.Models;
    using Castle.Core.Resource;
    using FunderApi;
    using NUnit.Framework;

    public class ApplicationStatusResponseTests
    {
        [Test]
        public void StatusUpdateTest()
        {
            // Arrange
            var response = new ApplicationStatusResponse();
            var expectedStatusUpdate = new Decision();

            // Act
            response.StatusUpdate = expectedStatusUpdate;
            var actualStatusUpdate = response.StatusUpdate;

            // Assert
            Assert.That(actualStatusUpdate, Is.EqualTo(expectedStatusUpdate));
        }

        [Test]
        public void QuoteIdTest()
        {
            // Arrange
            var response = new ApplicationStatusResponse();
            var expectedQuoteId = 123;

            // Act
            response.QuoteId = expectedQuoteId;
            var actualQuoteId = response.QuoteId;

            // Assert
            Assert.That(actualQuoteId, Is.EqualTo(expectedQuoteId));
        }

        [Test]
        public void ApplicationReferenceTest()
        {
            // Arrange
            var response = new ApplicationStatusResponse();
            var expectedApplicationReference = new ApplicationReference
            {
                ProposalId = 123,
                CustomerId = 246
            };

            // Act
            response.ApplicationReference = expectedApplicationReference;
            var actualApplicationReference = response.ApplicationReference;

            // Assert
            Assert.That(actualApplicationReference, Is.EqualTo(expectedApplicationReference));
        }
    }
}
