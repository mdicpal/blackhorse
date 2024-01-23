namespace UnitTests.DomainLayerTests.FunderService.Mappers;

using ApplicationLayer.Extensions.ApiExceptions;
using ApplicationLayer.Handlers;
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

public class MakeApplicationResponseMapperTests
{    
    private Mock<ICommonResponseMapper> _commonResponseMapper;

    private MakeApplicationActivitySuccessResponseMapper _makeApplicationActivitySuccessResponseMapper = null!;
    private MakeApplicationActivityFailedResponseMapper _makeApplicationActivityFailedResponseMapper = null!;

    [SetUp]
    public void SetUp()
    {        
        _commonResponseMapper = new Mock<ICommonResponseMapper>();
        _makeApplicationActivitySuccessResponseMapper = new MakeApplicationActivitySuccessResponseMapper(_commonResponseMapper.Object);
        _makeApplicationActivityFailedResponseMapper = new MakeApplicationActivityFailedResponseMapper(_commonResponseMapper.Object);       
    }

    [Test]
    public void SuccessfulMakeApplicationMapperTest()
    {
        var request = new MakeApplicationActivityRequest
        {
            ApplicationRequest = new ApplicationRequest()
            {
                QuoteId = 123
            }
        };
       
        SendApplicationRequest funderRequest = new () { Individual = new Individual { First_name = "MMMM", Middle_initial = "RRRR" } };
        SendApplicationResponse funderResponse = new () { Customer_id = "2200", Proposal_id = "4400" };

        ApplicationReference references = new ();

        _commonResponseMapper
            .Setup(x => x.Map(request.ApplicationRequest.QuoteId, references, It.IsAny<StatusResponse>(), funderRequest, funderResponse))
            .Returns(It.IsAny<CommonResponse<StatusResponse>>());

        MakeApplicationActivityResponse successResponse = _makeApplicationActivitySuccessResponseMapper.Map(request.ApplicationRequest.QuoteId, funderRequest, funderResponse);

        Assert.That(successResponse, Is.Not.Null);
    }
    [Test]
    public void FailedMakeApplicationMapperTest()
    {
        var request = new MakeApplicationActivityRequest
        {
            ApplicationRequest = new ()
            {
                QuoteId = 123
            }
        };
       
        SendApplicationRequest funderRequest = new () { Individual = new Individual { First_name = "MMMM", Middle_initial = "RRR" } };
        GenericErrorResponse funderResponse = new () { ResponseMessage = "error message" };

        

        _commonResponseMapper
            .Setup(x => x.Map(request.ApplicationRequest.QuoteId, null, It.IsAny<FunderErrors>(), funderRequest, funderResponse))
            .Returns(It.IsAny<CommonResponse<FunderErrors>>());

        MakeApplicationActivityResponse successResponse = _makeApplicationActivityFailedResponseMapper.Map(request.ApplicationRequest.QuoteId, funderRequest, funderResponse);

        Assert.That(successResponse, Is.Not.Null);
    }

    [Test]
    public void ValidationFailedResponseMapperTest()
    {
        ValidationFailedResponseMapper validationFailedResponseMapper = new(_commonResponseMapper.Object);
        ValidationFailure validationFailure = new("PN","EM");
        IEnumerable<ValidationFailure> validationFailures = new List<ValidationFailure>(){ validationFailure };
        var successResponse =  validationFailedResponseMapper.Map<MakeApplicationActivityResponse>(It.IsAny<int>(),It.IsAny<string>(), validationFailures);
        Assert.That(successResponse, Is.Not.Null);
    }
}