namespace UnitTests.DomainLayerTests.FunderService.Mappers;

using ApplicationLayer.Extensions.ApiExceptions;
using ApplicationLayer.Handlers;
using ApplicationLayer.Handlers.Amendments;
using ApplicationLayer.Handlers.Amendments.Interfaces;
using ApplicationLayer.Handlers.Amendments.Models;
using ApplicationLayer.Handlers.Interfaces;
using ApplicationLayer.Handlers.MakeApplication;
using ApplicationLayer.Handlers.MakeApplication.Interfaces;
using ApplicationLayer.Handlers.MakeApplication.Models;
using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using AzureFunderCommonMessages.DotNet.Request;
using AzureFunderCommonMessages.DotNet.Response;
using AzureFunderCommonMessages.DotNet.Response.SubResponses;
using Domain.Logger;
using FluentValidation;
using FluentValidation.Results;
using FunderApi;
using Microsoft.Extensions.Logging;
using Moq;
using Orchestrator.Exceptions;
using Orchestrator.Triggers;

public class AmendApplicationResponseMapperTests
{

    private Mock<IAmendApplicationActivitySuccessResponseMapper> _successResponseMapperMock = null!;
    private Mock<IAmendApplicationActivityFailedResponseMapper> _failedResponseMapperMock = null!;
    private Mock<ICommonResponseMapper> _commonResponseMapper = null!;

    private AmendApplicationActivitySuccessResponseMapper _amendApplicationActivitySuccessResponseMapper = null!;
    private AmendApplicationActivityFailedResponseMapper _amendApplicationActivityFailedResponseMapper = null!;

    [SetUp]
    public void SetUp()
    {
        _successResponseMapperMock = new Mock<IAmendApplicationActivitySuccessResponseMapper>();
        _failedResponseMapperMock = new Mock<IAmendApplicationActivityFailedResponseMapper>();
        _commonResponseMapper = new Mock<ICommonResponseMapper>();
        _amendApplicationActivitySuccessResponseMapper = new AmendApplicationActivitySuccessResponseMapper(_commonResponseMapper.Object);
        _amendApplicationActivityFailedResponseMapper = new AmendApplicationActivityFailedResponseMapper(_commonResponseMapper.Object);       
    }

    [Test]
    public Task SuccessfulAmendApplicationMapperTest()
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
      
        SendApplicationRequest funderRequest = new() { Individual = new Individual { First_name = "abc", Middle_initial = "cde" } };
        PutCustomerResponse funderResponse = new() { Customer_id = "123", Proposal_id = "456" };
        ApplicationReference references = new ApplicationReference();

        _commonResponseMapper
            .Setup(x => x.Map(request.ApplicationRequest.QuoteId, references, It.IsAny<StatusResponse>(), funderRequest, funderResponse))
            .Returns(It.IsAny<CommonResponse<StatusResponse>>());

        // Act
       AmendApplicationActivityResponse successResponse = _amendApplicationActivitySuccessResponseMapper.Map(request.ApplicationRequest.QuoteId, funderRequest, funderResponse);

        // Assert
        Assert.That(successResponse, Is.Not.Null);
        return Task.CompletedTask;
    }

    [Test]
    public Task FailedAmendApplicationMapperTest()
    {
        // Arrange
        var request = new MakeApplicationActivityRequest
        {
            ApplicationRequest = new ApplicationRequest()
            {
                QuoteId = 123
            }
        };        
        SendApplicationRequest funderRequest = new SendApplicationRequest { Individual = new Individual { First_name = "MMMM", Middle_initial = "MMMM" } };
        GenericErrorResponse funderResponse = new GenericErrorResponse { ResponseMessage = "error message" };

        

        _commonResponseMapper
            .Setup(x => x.Map(request.ApplicationRequest.QuoteId, null, It.IsAny<FunderErrors>(), funderRequest, funderResponse))
            .Returns(It.IsAny<CommonResponse<FunderErrors>>());

        // Act
        AmendApplicationActivityResponse successResponse = _amendApplicationActivityFailedResponseMapper.Map(request.ApplicationRequest.QuoteId, funderRequest, funderResponse);

        // Assert
        Assert.That(successResponse, Is.Not.Null);
        return Task.CompletedTask;
    }
}