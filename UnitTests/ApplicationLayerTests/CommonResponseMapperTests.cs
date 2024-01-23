namespace UnitTests.ApplicationLayerTests;

using ApplicationLayer.Handlers;
using ApplicationLayer.Models;
using AzureFunderCommonMessages.DotNet.Response.SubResponses;
using AzureFunderCommonMessages.DotNet.Types;

public class CommonResponseMapperTests
{
    [Test]
    public void Map_ReturnsCommonResponseWithCorrectValues()
    {
        // Arrange
        const string funderCode = "ABC";
        const int quoteId = 123;
        const int proposalId = 1234;
        const int customerId = 12345;
        var subMessage = new StatusResponse();
        var requestObject = new RequestObject();
        var responseObject = new ResponseObject();

        var mapper = new CommonResponseMapper(funderCode);

        // Act
        ApplicationReference applicationReference = new ApplicationReference
        {
            ProposalId = proposalId,
            CustomerId = customerId
        };
        var commonResponse = mapper.Map(quoteId, applicationReference, subMessage, requestObject, responseObject);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(commonResponse, Is.Not.Null);
            Assert.That(commonResponse.FunderCode, Is.EqualTo(funderCode));
            Assert.That(commonResponse.QuoteId, Is.EqualTo(quoteId));
            Assert.That(commonResponse.FunderReference, Is.Not.Null);
            Assert.That(commonResponse.FunderReference!.Application, Is.EqualTo(proposalId.ToString()));
            Assert.That(commonResponse.SubResponse, Is.EqualTo(subMessage));
                
            Assert.That(commonResponse.RawRequestResponseData.First(x => x.Direction == DirectionType.REQUEST), Is.Not.Null);
            Assert.That(commonResponse.RawRequestResponseData.First(x => x.Direction == DirectionType.RESPONSE), Is.Not.Null);
        });
    }

    private class RequestObject
    {
        public string Test { get; } = "Request";
    }

    private class ResponseObject
    {
        public string Test { get; } = "Response";
    }
}