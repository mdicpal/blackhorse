namespace UnitTests.ApplicationLayerTests.Handlers.MakeApplication;

using ApplicationLayer.Extensions.ApiExceptions;
using ApplicationLayer.Handlers.MakeApplication;
using ApplicationLayer.Handlers.MakeApplication.Interfaces;
using ApplicationLayer.Handlers.MakeApplication.Models;
using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using AzureFunderCommonMessages.DotNet.Request;
using Domain.Logger;
using FluentValidation;
using FluentValidation.Results;
using FunderApi;
using FunderService.Clients;
using FunderService.Interfaces;
using FunderService.Mappers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Orchestrator.Exceptions;
using Orchestrator.Triggers;

public class MakeApplicationHandlerTests
{
    private Mock<IFunderClient> _funderClientMock = null!;
    private Mock<ICustomerMapper> _CustomerMapperMock = null!;
    private Mock<IMakeApplicationActivitySuccessResponseMapper> _successResponseMapperMock = null!;
    private Mock<IMakeApplicationActivityFailedResponseMapper> _failedResponseMapperMock = null!;
    private Mock<IValidationFailedResponseMapper> _validationfailedResponseMapperMock = null!;

    private MakeApplicationHandler _makeApplicationHandler = null!;

    [SetUp]
    public void SetUp()
    {
        _funderClientMock = new Mock<IFunderClient>();
        _CustomerMapperMock = new Mock<ICustomerMapper>();
        _successResponseMapperMock = new Mock<IMakeApplicationActivitySuccessResponseMapper>();
        _failedResponseMapperMock = new Mock<IMakeApplicationActivityFailedResponseMapper>();
        _validationfailedResponseMapperMock = new Mock<IValidationFailedResponseMapper>();
        var logger = new Mock<ILogger<MakeApplicationHandler>>();

        _makeApplicationHandler = new MakeApplicationHandler(
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
        int majorDealerId = 25000000;
        int minorDealerId = 57076700;
        string idempotency = DateTime.Now.ToString("yyyymmddhhmmss");
        var request = new MakeApplicationActivityRequest
        {
            ApplicationRequest = new ApplicationRequest()
            {
                QuoteId = 123
            }
        };

        var successResponse = new MakeApplicationActivityResponse();
        SendApplicationRequest funderRequest = new () { Individual = new Individual { First_name = "MMMM", Middle_initial = "RRRR" } };
        _CustomerMapperMock
            .Setup(x => x.Map(request.ApplicationRequest,null,null))
            .Returns(funderRequest);

        _funderClientMock
            .Setup(x => x.SendApplicationAsync(majorDealerId, minorDealerId, idempotency,funderRequest))
            .ReturnsAsync(It.IsAny<SendApplicationResponse>());

        _successResponseMapperMock
            .Setup(x => x.Map(request.ApplicationRequest.QuoteId, funderRequest, It.IsAny<SendApplicationResponse>()))
            .Returns(successResponse);

        // Act
        var response = await _makeApplicationHandler.Run(request);
        FunderClient funderClient = new FunderClient("", new HttpClient());
        var sendApplicationResponse = funderClient.SendapplicationAsync(majorDealerId, minorDealerId, idempotency, funderRequest);
        var updateApplicationResponse = funderClient.UpdateApplicationAsync(majorDealerId, minorDealerId, idempotency, funderRequest,101);
        var sendSubmitResponse = funderClient.SendSubmitAsync(majorDealerId, minorDealerId, idempotency, 202,101);
        var notTakenUpResponse = funderClient.NotTakenUpAsync(majorDealerId, minorDealerId, idempotency, 202,101);
        var getPlanResponse = funderClient.GetPlansAsync(majorDealerId, minorDealerId,101);
        var uploadResponse = funderClient.UploadAsync(majorDealerId, minorDealerId, idempotency, 202, 101,new PostUploadRequest());
        var getAppstatusResponse = funderClient.GetApplicationStatusAsync(majorDealerId, minorDealerId,  202, 101);
        // Assert
        Assert.Multiple(() =>
        {
        Assert.That(response, Is.EqualTo(successResponse));
        Assert.That(sendApplicationResponse, Is.Not.Null);
        Assert.That(updateApplicationResponse, Is.Not.Null);
        Assert.That(sendSubmitResponse, Is.Not.Null);
        Assert.That(notTakenUpResponse, Is.Not.Null);
        Assert.That(getPlanResponse, Is.Not.Null);
        Assert.That(uploadResponse, Is.Not.Null);
        Assert.That(getAppstatusResponse, Is.Not.Null);           
        });
    }

    [Test]
    public async Task ValidationExceptionMakeApplicationTest()
    {
        // Arrange
        var request = new MakeApplicationActivityRequest
        {
            ApplicationRequest = new ApplicationRequest()
            {
                QuoteId = 123
            }
        };

        var successResponse = new MakeApplicationActivityResponse();       
        _validationfailedResponseMapperMock
            .Setup(x => x.Map<MakeApplicationActivityResponse>(
                request.ApplicationRequest.QuoteId, null, 
                It.IsAny<IEnumerable<ValidationFailure>>())).Returns(successResponse);
        _CustomerMapperMock
            .Setup(x => x.Map(request.ApplicationRequest, null, null))
            .Throws(new ValidationException(""));
        // Act
        var response = await _makeApplicationHandler.Run(request);

        // Assert
        Assert.That(response, Is.EqualTo(successResponse));
    }

    [Test]
    public async Task ApiExceptionGenericErrorResponseMakeApplicationTest()
    {
        // Arrange
        var request = new MakeApplicationActivityRequest
        {
            ApplicationRequest = new ApplicationRequest()
            {
                QuoteId = 123
            }
        };

        var successResponse = new MakeApplicationActivityResponse();
        _failedResponseMapperMock
            .Setup(x => x.Map(
                request.ApplicationRequest.QuoteId, It.IsAny<SendApplicationRequest>(),
                It.IsAny<GenericErrorResponse>())).Returns(successResponse);
        _CustomerMapperMock
            .Setup(x => x.Map(request.ApplicationRequest, null, null))
            .Throws(new ApiException<GenericErrorResponse>("",0,"",It.IsAny<IReadOnlyDictionary<string,IEnumerable<string>>>(), It.IsAny<GenericErrorResponse>(), It.IsAny<Exception>()));
        // Act
        var response = await _makeApplicationHandler.Run(request);

        // Assert
        Assert.That(response, Is.EqualTo(successResponse));
    }
    [Test]
    public async Task ApiExceptionOnlyMakeApplicationTest()
    {
        // Arrange
        var request = new MakeApplicationActivityRequest
        {
            ApplicationRequest = new ApplicationRequest()
            {
                QuoteId = 123
            }
        };

        var successResponse = new MakeApplicationActivityResponse();
        
        _failedResponseMapperMock
    .Setup(x => x.Map(
        request.ApplicationRequest.QuoteId, It.IsAny<string>(), It.IsAny<SendApplicationRequest>(),
        It.IsAny<GenericErrorResponse>())).Returns(successResponse);
       
        _CustomerMapperMock
            .Setup(x => x.Map(request.ApplicationRequest, null, null))
            .Throws(new ApiException<string>("", 400, "", It.IsAny<IReadOnlyDictionary<string, IEnumerable<string>>>(), It.IsAny<string>(), It.IsAny<Exception>()));
        // Act
        var response = await _makeApplicationHandler.Run(request);

        // Assert
        Assert.That(response, Is.EqualTo(successResponse));
    }

    [Test]
    public async Task ApiExceptionwithstringMakeApplicationTest()
    {
        // Arrange
        var request = new MakeApplicationActivityRequest
        {
            ApplicationRequest = new ApplicationRequest()
            {
                QuoteId = 123
            }
        };

        var successResponse = new MakeApplicationActivityResponse();

        _failedResponseMapperMock
    .Setup(x => x.Map(
        request.ApplicationRequest.QuoteId, It.IsAny<string>(), It.IsAny<SendApplicationRequest>(),null)).Returns(successResponse);

        _CustomerMapperMock
            .Setup(x => x.Map(request.ApplicationRequest, null, null))           
            .Throws(new ApiException("",404,"", It.IsAny<IReadOnlyDictionary<string, IEnumerable<string>>>(), It.IsAny<Exception>()));
        // Act
        var response = await _makeApplicationHandler.Run(request);

        // Assert
        Assert.That(response, Is.EqualTo(successResponse));
    }
    [Test]
    public void ExceptionMakeApplicationTest()
    {
        // Arrange
        var request = new MakeApplicationActivityRequest
        {
            ApplicationRequest = new ApplicationRequest()
            {
                QuoteId = 123
            }
        };

        _CustomerMapperMock
            .Setup(x => x.Map(request.ApplicationRequest, null, null))
            .Throws(new Exception(""));
        Assert.ThrowsAsync<Exception>(async () => await _makeApplicationHandler.Run(request));
    }

}