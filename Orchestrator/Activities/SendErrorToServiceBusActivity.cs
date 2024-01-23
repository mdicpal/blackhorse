namespace Orchestrator.Activities;

using ApplicationLayer.Handlers.Interfaces;
using ApplicationLayer.Models;
using Azure.Messaging.ServiceBus;
using AzureFunderCommonMessages.DotNet.Extensions;
using AzureFunderCommonMessages.DotNet.Response.SubResponses;
using Domain.Logger;
using Extensions;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Extensions.Logging;
using Orchestrator.Activities.Application;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class SendErrorToServiceBusActivity
{
    private readonly ICommonResponseMapper _commonResponseMapper;
    private readonly ILoggerAdapter<SendErrorToServiceBusActivity> _logger;

    public SendErrorToServiceBusActivity(ICommonResponseMapper commonResponseMapper, ILoggerAdapter<SendErrorToServiceBusActivity> logger)
    {
        _commonResponseMapper = commonResponseMapper;
        _logger = logger;
    }
    
    [FunctionName(nameof(SendErrorToServiceBusActivity))]
    public async Task ActivityFunction(
        [ActivityTrigger] SendErrorToServiceBusActivityRequest  request,
        [ServiceBus("%TopicName%", ServiceBusEntityType.Topic, Connection = "ServiceBusConnectionString")]
        IAsyncCollector<ServiceBusMessage> serviceBus
    )
    {
        try
        {
            var subResponse = new ErrorResponse { Errors = new List<string> { request.ErrorMessage } };
            var commonResponse = _commonResponseMapper.Map(request.QuoteId, request.ApplicationReference, subResponse);
            ServiceBusMessage serviceBusMessage = new ServiceBusMessage(commonResponse.ToJson());
            serviceBusMessage.SetApplicationPropertiesFromMessage(commonResponse);
            await serviceBus.AddAsync(serviceBusMessage);
        }
        catch (Exception ex)
        {
            _logger.LogError(request.QuoteId, ex.Message, "Exception thrown in SendErrorToServiceBus Activity Trigger");
            throw;
        }
    }
}