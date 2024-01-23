using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;

namespace Orchestrator.Triggers;

using ApplicationLayer.Models;
using Azure.Messaging.ServiceBus;
using AzureFunderCommonMessages.DotNet.Extensions;
using AzureFunderCommonMessages.DotNet.Request;
using Domain.Logger;
using Exceptions;
using InstanceStoreAdapter.Interfaces;
using Interfaces;
using Microsoft.Extensions.Logging;
using Orchestrator.Activities;
using System;

public class MakeApplicationTrigger
{
    private readonly ILoggerAdapter<MakeApplicationTrigger> _logger;
    private readonly IInstanceStoreServiceAdapter _instanceStoreAdapter;
    private readonly IRaiseAmendmentTrigger _raiseAmendmentTrigger;
    private readonly INewApplicationTrigger _newApplicationTrigger;
    private ApplicationRequest request = null!;

    public MakeApplicationTrigger(
        ILoggerAdapter<MakeApplicationTrigger> logger, 
        IInstanceStoreServiceAdapter instanceStoreAdapter,
        IRaiseAmendmentTrigger raiseAmendmentTrigger,
        INewApplicationTrigger newApplicationTrigger
        )
    {
        _logger = logger;
        _instanceStoreAdapter = instanceStoreAdapter;
        _raiseAmendmentTrigger = raiseAmendmentTrigger;
        _newApplicationTrigger = newApplicationTrigger;
    }
    
    /**
     * <summary>
     * Service bus trigger, called when a make application request is found on the service bus.
     * </summary>
     */
    [FunctionName("MakeApplicationTrigger")]
    public async Task RunAsync(
        [ServiceBusTrigger("%TopicName%", "%MakeApplicationSubscription%", Connection = "ServiceBusConnectionString")] ServiceBusReceivedMessage serviceBusMessage, 
        [DurableClient] IDurableOrchestrationClient orchestrationClient
    )
    {
        try
        {
            request = serviceBusMessage.Body.FromJson<ApplicationRequest>();
            _logger.LogInformation(request!.QuoteId, "Make ApplicationLayer trigger hit");
            Instance instance = await _instanceStoreAdapter.GetAsync(request.QuoteId);
            if (instance is not null && instance.IsInProgress())
            {
                _logger.LogInformation(instance.QuoteId, "Ongoing Orchestration Found for {ApplicationId}", instance.ApplicationId);
                await _raiseAmendmentTrigger.RunAsync(orchestrationClient, request, instance.Id);
                return;
            }

            await _newApplicationTrigger.RunAsync(orchestrationClient, request);
        }
        catch (InvalidOrchestrationException)
        {
            _logger.LogInformation(request!.QuoteId, "Failed to raise amendment event");
            await _newApplicationTrigger.RunAsync(orchestrationClient, request);
        }
        catch (Exception e)
        {
            _logger.LogError(e, request!.QuoteId, "Exception thrown in Make ApplicationLayer Trigger");
        }
    }
}