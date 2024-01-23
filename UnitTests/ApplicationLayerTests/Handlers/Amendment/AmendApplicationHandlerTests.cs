namespace UnitTests.ApplicationLayerTests.Handlers.Amendment;

using ApplicationLayer.Handlers.Amendments;
using ApplicationLayer.Handlers.Amendments.Interfaces;
using ApplicationLayer.Handlers.Amendments.Models;
using ApplicationLayer.Handlers.MakeApplication.Models;
using ApplicationLayer.Interfaces;
using AzureFunderCommonMessages.DotNet.Request;
using Domain.Logger;
using FluentValidation;
using FluentValidation.Results;
using FunderApi;
using FunderService.Interfaces;
using FunderService.Mappers.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;

public class AmendApplicationHandlerTests
{
    private Mock<IFunderClient> _funderClientMock = null!;
    private Mock<ICustomerMapper> _CustomerMapperMock = null!;
    private Mock<IAmendApplicationActivitySuccessResponseMapper> _successResponseMapperMock = null!;
    private Mock<IAmendApplicationActivityFailedResponseMapper> _failedResponseMapperMock = null!;
    private Mock<IValidationFailedResponseMapper> _validationfailedResponseMapperMock = null!;

    private AmendApplicationHandler _amendApplicationHandler = null!;

    [SetUp]
    public void SetUp()
    {
        _funderClientMock = new Mock<IFunderClient>();
        _CustomerMapperMock = new Mock<ICustomerMapper>();
        _successResponseMapperMock = new Mock<IAmendApplicationActivitySuccessResponseMapper>();
        _failedResponseMapperMock = new Mock<IAmendApplicationActivityFailedResponseMapper>();
        _validationfailedResponseMapperMock = new Mock<IValidationFailedResponseMapper>();
        var logger = new Mock<ILogger<AmendApplicationHandler>>();

        _amendApplicationHandler = new AmendApplicationHandler(
            _funderClientMock.Object,
            _CustomerMapperMock.Object,
            _successResponseMapperMock.Object,
            _failedResponseMapperMock.Object,
            _validationfailedResponseMapperMock.Object,
            logger.Object
        );
    }

    [Test]
    public async Task SuccessfulApplicationTest()
    {
        // Arrange
        int majorDealerId = Convert.ToInt32(Environment.GetEnvironmentVariable("x-lbg-major-dealerId"));
        int minorDealerId = Convert.ToInt32(Environment.GetEnvironmentVariable("x-lbg-minor-dealerId"));
        string idempotency = DateTime.Now.ToString("yyyymmddhhmmss");
        var request = new AmendApplicationActivityRequest
        {
            ApplicationReference = new()
            {
                ProposalId =456,
                CustomerId =123 
            },
            ApplicationRequest = new ApplicationRequest()
            {
                QuoteId = 123
            }
        };

        var successResponse = new AmendApplicationActivityResponse()
        {
            ApplicationStatus = AzureFunderCommonMessages.DotNet.Types.StatusResponseType.Accepted,
            ApplicationReference = new()
            {
                ProposalId = 123,
                CustomerId = 456
            },
             Success = true
        };
        SendApplicationRequest funderRequest = new () { Individual = new Individual { First_name = "abc", Middle_initial = "cde" } };
        PutCustomerResponse funderResponse = new () { Customer_id = "AS11", Proposal_id = "MD123" };
        _CustomerMapperMock
            .Setup(x => x.Map(request.ApplicationRequest,request.ApplicationReference.CustomerId,request.ApplicationReference.ProposalId))
            .Returns(funderRequest);

        _funderClientMock
            .Setup(x => x.UpdateApplicationAsync(majorDealerId,minorDealerId,idempotency,funderRequest, request.ApplicationReference.CustomerId))
            .ReturnsAsync(funderResponse);

        _successResponseMapperMock
            .Setup(x => x.Map(request.ApplicationRequest.QuoteId, funderRequest, funderResponse))
            .Returns(successResponse);

        var response = await _amendApplicationHandler.Run(request);
        Assert.That(response, Is.EqualTo(successResponse));
    }

    [Test]
    public async Task ValidationExceptionTest()
    {
        // Arrange
        var request = new AmendApplicationActivityRequest
        {
            ApplicationReference = new()
            {
                ProposalId = 456,
                CustomerId = 123
            },
            ApplicationRequest = new ApplicationRequest()
            {
                QuoteId = 123
            }
        };

        var successResponse = new AmendApplicationActivityResponse()
        {
            ApplicationStatus = AzureFunderCommonMessages.DotNet.Types.StatusResponseType.Error,
            ApplicationReference = new()
            {
                ProposalId = 123,
                CustomerId = 456
            },
            Success = false
        };
        _validationfailedResponseMapperMock
            .Setup(x => x.Map<AmendApplicationActivityResponse>(
                request.ApplicationRequest.QuoteId, null,
                It.IsAny<IEnumerable<ValidationFailure>>())).Returns(successResponse);
        _CustomerMapperMock
            .Setup(x => x.Map(request.ApplicationRequest, request.ApplicationReference.CustomerId, request.ApplicationReference.ProposalId))
            .Throws(new ValidationException(""));
        // Act
        var response = await _amendApplicationHandler.Run(request);

        // Assert
        Assert.That(response, Is.EqualTo(successResponse));
    }

    [Test]
    public async Task ApiExceptionGenericErrorResponseTest()
    {
        // Arrange
        var request = new AmendApplicationActivityRequest
        {
            ApplicationReference = new()
            {
                ProposalId = 456,
                CustomerId = 123
            },
            ApplicationRequest = new ApplicationRequest()
            {
                QuoteId = 123
            }
        };

        var successResponse = new AmendApplicationActivityResponse()
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
                request.ApplicationRequest.QuoteId, It.IsAny<SendApplicationRequest>(),
                It.IsAny<GenericErrorResponse>())).Returns(successResponse);
        _CustomerMapperMock
            .Setup(x => x.Map(request.ApplicationRequest, request.ApplicationReference.CustomerId, request.ApplicationReference.ProposalId))
            .Throws(new ApiException<GenericErrorResponse>("", 0, "", It.IsAny<IReadOnlyDictionary<string, IEnumerable<string>>>(), It.IsAny<GenericErrorResponse>(), It.IsAny<Exception>()));
        // Act
        var response = await _amendApplicationHandler.Run(request);

        // Assert
        Assert.That(response, Is.EqualTo(successResponse));
    }

    [Test]
    public async Task ApiExceptionOnlyMakeApplicationTest()
    {
        // Arrange
        var request = new AmendApplicationActivityRequest
        {
            ApplicationReference = new()
            {
                ProposalId = 456,
                CustomerId = 123
            },
            ApplicationRequest = new ApplicationRequest()
            {
                QuoteId = 123
            }
        };

        var successResponse = new AmendApplicationActivityResponse()
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
        request.ApplicationRequest.QuoteId, It.IsAny<string>(), It.IsAny<SendApplicationRequest>(),
        It.IsAny<GenericErrorResponse>())).Returns(successResponse);

        _CustomerMapperMock
            .Setup(x => x.Map(request.ApplicationRequest, request.ApplicationReference.CustomerId, request.ApplicationReference.ProposalId))
            .Throws(new ApiException<string>("", 400, "", It.IsAny<IReadOnlyDictionary<string, IEnumerable<string>>>(), It.IsAny<string>(), It.IsAny<Exception>()));
        // Act
        var response = await _amendApplicationHandler.Run(request);

        // Assert
        Assert.That(response, Is.EqualTo(successResponse));
    }

    [Test]
    public async Task ApiExceptionwithstringMakeApplicationTest()
    {
        // Arrange
        var request = new AmendApplicationActivityRequest
        {
            ApplicationReference = new()
            {
                ProposalId = 456,
                CustomerId = 123
            },
            ApplicationRequest = new ApplicationRequest()
            {
                QuoteId = 123
            }
        };

        var successResponse = new AmendApplicationActivityResponse()
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
        request.ApplicationRequest.QuoteId, It.IsAny<string>(), It.IsAny<SendApplicationRequest>(), null)).Returns(successResponse);

        _CustomerMapperMock
            .Setup(x => x.Map(request.ApplicationRequest, request.ApplicationReference.CustomerId, request.ApplicationReference.ProposalId))
            .Throws(new ApiException("", 404, "", It.IsAny<IReadOnlyDictionary<string, IEnumerable<string>>>(), It.IsAny<Exception>()));
        // Act
        var response = await _amendApplicationHandler.Run(request);

        // Assert
        Assert.That(response, Is.EqualTo(successResponse));
    }
    [Test]
    public Task ExceptionMakeApplicationTest()
    {
        // Arrange
        var request = new AmendApplicationActivityRequest
        {
            ApplicationReference = new()
            {
                ProposalId = 456,
                CustomerId = 123
            },
            ApplicationRequest = new ApplicationRequest()
            {
                QuoteId = 123
            }
        };     

        _CustomerMapperMock
            .Setup(x => x.Map(request.ApplicationRequest, request.ApplicationReference.CustomerId, request.ApplicationReference.ProposalId))
            .Throws(new Exception(""));
        Assert.ThrowsAsync<Exception>(async () => await _amendApplicationHandler.Run(request));
        return Task.CompletedTask;
    }
}