namespace UnitTests.ApplicationLayerTests.Handlers.Amendments
{
    using System;
    using System.Threading.Tasks;
    using ApplicationLayer.Handlers.Amendments;
    using ApplicationLayer.Handlers.Amendments.Interfaces;
    using ApplicationLayer.Handlers.Amendments.Models;
    using Domain.Logger;
    using FunderApi;
    using ApplicationLayer.Interfaces;
    using FunderService.Interfaces;
    using Moq;
    using NUnit;
    using ApplicationLayer.Handlers.MakeApplication.Models;
    using FluentValidation;
    using FluentValidation.Results;
    using System.Collections.Generic;
    using Microsoft.Extensions.Logging;
    using ApplicationLayer.Extensions.ApiExceptions;
    using System.Net;
    using AzureFunderCommonMessages.DotNet.Request;

    public class AmendSubmitHandlerTests
    {
        private Mock<IFunderClient> _funderClientMock = null!;
        private Mock<IAmendSubmitSuccessResponseMapper> _successResponseMapperMock = null!;
        private Mock<IAmendSubmitActivityFailedResponseMapper> _failedResponseMapperMock = null!;
        private Mock<IValidationFailedResponseMapper> _validationFailedResponseMapperMock = null!;
        private Mock<ILogger<AmendSubmitHandler>> _loggerMock = null!;
        private AmendSubmitHandler _amendSubmitHandler = null!;

        [SetUp]
        public void SetUp()
        {
            _funderClientMock = new Mock<IFunderClient>();
            _successResponseMapperMock = new Mock<IAmendSubmitSuccessResponseMapper>();
            _failedResponseMapperMock = new Mock<IAmendSubmitActivityFailedResponseMapper>();
            _validationFailedResponseMapperMock = new Mock<IValidationFailedResponseMapper>();
            _loggerMock = new Mock<ILogger<AmendSubmitHandler>>();

            _amendSubmitHandler = new AmendSubmitHandler(
                _funderClientMock.Object,
                _successResponseMapperMock.Object,
                _failedResponseMapperMock.Object,
                _validationFailedResponseMapperMock.Object,
                _loggerMock.Object);
        }

        [Test]
        public async Task AmendSubmitSuccessResponseTest()
        {
            int majorDealerId = Convert.ToInt32(Environment.GetEnvironmentVariable("x-lbg-major-dealerId"));
            int minorDealerId = Convert.ToInt32(Environment.GetEnvironmentVariable("x-lbg-minor-dealerId"));
            string idempotency = DateTime.Now.ToString("yyyymmddhhmmss");
            // Arrange
            var amendmentSubmitActivityRequest = new AmendSubmitActivityRequest
            {
                ApplicationRequest = new() { QuoteId = 123 },
                CustomerId = "123",
                ProposalId = "234",
                ApplicationId = 123
            };

            var funderResponse = new PostSubmitResponse
            {
                Customer_permission_given = "",
                Proposal = new Proposal { },
                Decision = new Decision2 { },
                Terms = new Terms { },
                Payments = null,
                Months_to_first_payment = "",
                Not_taken_up = "",
                Changes = null,
                Agreements_available_to_contra = null,
                _links = null,
                AdditionalProperties = null
            };

            var successResponse = new AmendSubmitActivityResponse()
            {
                ApplicationStatus = AzureFunderCommonMessages.DotNet.Types.StatusResponseType.Accepted,
                ApplicationReference = new()
                {
                    ProposalId = 123,
                    CustomerId = 456
                },
                Success = true
            };

            _funderClientMock.Setup(client => client.SendSubmitAsync(majorDealerId, minorDealerId, idempotency,Convert.ToInt32(amendmentSubmitActivityRequest.CustomerId), Convert.ToInt32(amendmentSubmitActivityRequest.ProposalId))).ReturnsAsync(funderResponse);

            _successResponseMapperMock
           .Setup(x => x.Map(amendmentSubmitActivityRequest.ApplicationRequest.QuoteId, amendmentSubmitActivityRequest.CustomerId, amendmentSubmitActivityRequest.ProposalId, funderResponse))
           .Returns(successResponse);

            var actResponse = await _amendSubmitHandler.Run(amendmentSubmitActivityRequest);

            Assert.That(actResponse, Is.EqualTo(successResponse));
        }
        [Test]
        public async Task AmendSubmitValidationExceptionTest()
        {
            int majorDealerId = Convert.ToInt32(Environment.GetEnvironmentVariable("x-lbg-major-dealerId"));
            int minorDealerId = Convert.ToInt32(Environment.GetEnvironmentVariable("x-lbg-minor-dealerId"));
            string idempotency = DateTime.Now.ToString("yyyymmddhhmmss");
            // Arrange
            var amendmentSubmitActivityRequest = new AmendSubmitActivityRequest
            {
                ApplicationRequest = new() { QuoteId = 123 },
                CustomerId = "456",
                ProposalId = "234",
                ApplicationId = 123
            };

            var successResponse = new AmendSubmitActivityResponse()
            {
                ApplicationStatus = AzureFunderCommonMessages.DotNet.Types.StatusResponseType.Error,
                ApplicationReference = new()
                {
                    ProposalId = 123,
                    CustomerId = 456
                },
                Success = false
            };

            _validationFailedResponseMapperMock
                .Setup(x => x.Map<AmendSubmitActivityResponse>(
                    amendmentSubmitActivityRequest.ApplicationRequest.QuoteId, Convert.ToString(amendmentSubmitActivityRequest.ApplicationId),
                    It.IsAny<IEnumerable<ValidationFailure>>())).Returns(successResponse);

            _funderClientMock.Setup(client => client.SendSubmitAsync(majorDealerId,minorDealerId,idempotency,Convert.ToInt32(amendmentSubmitActivityRequest.CustomerId), Convert.ToInt32(amendmentSubmitActivityRequest.ProposalId))).ThrowsAsync(new ValidationException(""));

            //Act
            var actResponse = await _amendSubmitHandler.Run(amendmentSubmitActivityRequest);

            //Asert
            Assert.That(actResponse, Is.EqualTo(successResponse));

        }

        [Test]
        public async Task AmendSubmitApiExceptionGenericErrorResponseTest()
        {
            int majorDealerId = Convert.ToInt32(Environment.GetEnvironmentVariable("x-lbg-major-dealerId"));
            int minorDealerId = Convert.ToInt32(Environment.GetEnvironmentVariable("x-lbg-minor-dealerId"));
            string idempotency = DateTime.Now.ToString("yyyymmddhhmmss");
            // Arrange
            var amendmentSubmitActivityRequest = new AmendSubmitActivityRequest
            {
                ApplicationRequest = new() { QuoteId = 123 },
                CustomerId = "456",
                ProposalId = "234",
                ApplicationId = 123
            };

            var successResponse = new AmendSubmitActivityResponse()
            {
                ApplicationStatus = AzureFunderCommonMessages.DotNet.Types.StatusResponseType.Error,
                ApplicationReference = new()
                {
                    ProposalId = 123,
                    CustomerId = 456
                },
                Success = false
            };

            _failedResponseMapperMock
            .Setup(x => x.Map(
                amendmentSubmitActivityRequest.ApplicationRequest.QuoteId, amendmentSubmitActivityRequest.CustomerId, amendmentSubmitActivityRequest.ProposalId,
                It.IsAny<Exception>(), It.IsAny<GenericErrorResponse>())).Returns(successResponse);

            _funderClientMock.Setup(client => client.SendSubmitAsync(majorDealerId,minorDealerId,idempotency,Convert.ToInt32(amendmentSubmitActivityRequest.CustomerId),
                Convert.ToInt32(amendmentSubmitActivityRequest.ProposalId)))
                .ThrowsAsync(new ApiException<GenericErrorResponse>("Error Message", 400, "", It.IsAny<IReadOnlyDictionary<string, IEnumerable<string>>>(),
                It.IsAny<GenericErrorResponse>(), It.IsAny<Exception>()));

            //Act
            var actResponse = await _amendSubmitHandler.Run(amendmentSubmitActivityRequest);

            //Asert
            Assert.That(actResponse, Is.EqualTo(successResponse));
        }
        [Test]
        public async Task AmendSubmitApiExceptionStringWithNonTransientErrorTest()
        {
            // Arrange
            int majorDealerId = Convert.ToInt32(Environment.GetEnvironmentVariable("x-lbg-major-dealerId"));
            int minorDealerId = Convert.ToInt32(Environment.GetEnvironmentVariable("x-lbg-minor-dealerId"));
            string idempotency = DateTime.Now.ToString("yyyymmddhhmmss");
            var amendmentSubmitActivityRequest = new AmendSubmitActivityRequest
            {
                ApplicationRequest = new() { QuoteId = 123 },
                CustomerId = "456",
                ProposalId = "234",
                ApplicationId = 123
            };

            var successResponse = new AmendSubmitActivityResponse()
            {
                ApplicationStatus = AzureFunderCommonMessages.DotNet.Types.StatusResponseType.Error,
                ApplicationReference = new()
                {
                    ProposalId = 123,
                    CustomerId = 456
                },
                Success = false
            };

            _failedResponseMapperMock
            .Setup(x => x.Map(
                amendmentSubmitActivityRequest.ApplicationRequest.QuoteId, amendmentSubmitActivityRequest.CustomerId, amendmentSubmitActivityRequest.ProposalId,
                It.IsAny<Exception>(), It.IsAny<GenericErrorResponse>())).Returns(successResponse);

            _funderClientMock.Setup(client => client.SendSubmitAsync(majorDealerId,minorDealerId,idempotency,Convert.ToInt32(amendmentSubmitActivityRequest.CustomerId),
                Convert.ToInt32(amendmentSubmitActivityRequest.ProposalId)))
                .ThrowsAsync(new ApiException<string>("Error Message", 403, "", It.IsAny<IReadOnlyDictionary<string, IEnumerable<string>>>(), It.IsAny<string>(), It.IsAny<Exception>()));

            //Act
            var actResponse = await _amendSubmitHandler.Run(amendmentSubmitActivityRequest);

            //Asert
            Assert.That(actResponse, Is.EqualTo(successResponse));
        }

        [Test]
        public async Task AmendSubmitApiExceptionWithNonTransientErrorTest()
        {
            // Arrange
            int majorDealerId = Convert.ToInt32(Environment.GetEnvironmentVariable("x-lbg-major-dealerId"));
            int minorDealerId = Convert.ToInt32(Environment.GetEnvironmentVariable("x-lbg-minor-dealerId"));
            string idempotency = DateTime.Now.ToString("yyyymmddhhmmss");
            var amendmentSubmitActivityRequest = new AmendSubmitActivityRequest
            {
                ApplicationRequest = new() { QuoteId = 123 },
                CustomerId = "456",
                ProposalId = "234",
                ApplicationId = 123
            };

            var successResponse = new AmendSubmitActivityResponse()
            {
                ApplicationStatus = AzureFunderCommonMessages.DotNet.Types.StatusResponseType.Error,
                ApplicationReference = new()
                {
                    ProposalId = 123,
                    CustomerId = 456
                },
                Success = false
            };

            _failedResponseMapperMock
            .Setup(x => x.Map(
                amendmentSubmitActivityRequest.ApplicationRequest.QuoteId, amendmentSubmitActivityRequest.CustomerId, amendmentSubmitActivityRequest.ProposalId,
                It.IsAny<Exception>(), It.IsAny<GenericErrorResponse>())).Returns(successResponse);

            _funderClientMock.Setup(client => client.SendSubmitAsync(majorDealerId,minorDealerId,idempotency,Convert.ToInt32(amendmentSubmitActivityRequest.CustomerId),
                Convert.ToInt32(amendmentSubmitActivityRequest.ProposalId)))
                .ThrowsAsync(new ApiException("Error Message", 404, "", It.IsAny<IReadOnlyDictionary<string, IEnumerable<string>>>(), It.IsAny<Exception>()));

            //Act
            var actResponse = await _amendSubmitHandler.Run(amendmentSubmitActivityRequest);

            //Asert
            Assert.That(actResponse, Is.EqualTo(successResponse));
        }

        [Test]
        public void AmendSubmitExceptionTest()
        {
            int majorDealerId = Convert.ToInt32(Environment.GetEnvironmentVariable("x-lbg-major-dealerId"));
            int minorDealerId = Convert.ToInt32(Environment.GetEnvironmentVariable("x-lbg-minor-dealerId"));
            string idempotency = DateTime.Now.ToString("yyyymmddhhmmss");
            var amendmentSubmitActivityRequest = new AmendSubmitActivityRequest
            {
                ApplicationRequest = new() { QuoteId = -123 },
                CustomerId = "123",
                ProposalId = "234"
            };

            _funderClientMock.Setup(client => client.SendSubmitAsync(majorDealerId,minorDealerId,idempotency,Convert.ToInt32(amendmentSubmitActivityRequest.CustomerId), Convert.ToInt32(amendmentSubmitActivityRequest.ProposalId))).ThrowsAsync(new Exception());

            Assert.ThrowsAsync<Exception>(async () => await _amendSubmitHandler.Run(amendmentSubmitActivityRequest));
        }
    }

}