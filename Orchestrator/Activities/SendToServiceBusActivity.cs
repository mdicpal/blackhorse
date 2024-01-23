namespace Orchestrator.Activities;

using Azure.Messaging.ServiceBus;
using AzureFunderCommonMessages.DotNet.Extensions;
using AzureFunderCommonMessages.DotNet.Response;
using Domain.Logger;
using Extensions;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Extensions.Logging;
using Orchestrator.Activities.Application;
using Orchestrator.Triggers;
using System;
using System.Threading.Tasks;

public class SendToServiceBusActivity
{
    private readonly ILoggerAdapter<SendToServiceBusActivity> _logger;

    public SendToServiceBusActivity(ILoggerAdapter<SendToServiceBusActivity> logger)
    {
        _logger = logger;
    }

    [FunctionName(nameof(SendToServiceBusActivity))]
    public async Task ActivityFunction(
        [ActivityTrigger] CommonResponse commonResponse,
        [ServiceBus("%TopicName%", ServiceBusEntityType.Topic, Connection = "ServiceBusConnectionString")]
        IAsyncCollector<ServiceBusMessage> serviceBus
    )
    {
        try
        {
            ServiceBusMessage serviceBusMessage = new ServiceBusMessage(commonResponse.ToJson());
            serviceBusMessage.SetApplicationPropertiesFromMessage(commonResponse);
            await serviceBus.AddAsync(serviceBusMessage);
        }
        catch (Exception ex)
        {
            _logger.LogError(commonResponse.QuoteId, ex.Message, "Exception thrown in SendToServiceBus Activity Trigger");
            throw;
        }
    }
}