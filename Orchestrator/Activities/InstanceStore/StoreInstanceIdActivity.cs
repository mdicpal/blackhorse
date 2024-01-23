namespace Orchestrator.Activities.InstanceStore;

using ApplicationLayer.Models.Activities.InstanceStore;
using Domain.Logger;
using InstanceStoreAdapter.Interfaces;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using Orchestrator.Activities.Application;
using System;
using System.Threading.Tasks;

public class StoreInstanceIdActivity
{
    private readonly IInstanceStoreServiceAdapter _instanceStoreServiceAdapter;
    private readonly ILoggerAdapter<StoreInstanceIdActivity> _logger;

    public StoreInstanceIdActivity(IInstanceStoreServiceAdapter instanceStoreServiceAdapter, ILoggerAdapter<StoreInstanceIdActivity> logger)
    {
        _instanceStoreServiceAdapter = instanceStoreServiceAdapter;
        _logger = logger;
    }
        
    [FunctionName(nameof(StoreInstanceIdActivity))]
    public async Task Run([ActivityTrigger] StoreInstanceIdActivityRequest request)
    {
        try
        {
            await _instanceStoreServiceAdapter.CreateAsync(request.QuoteId, request.InstanceId);
        }
        catch (Exception ex)
        {
            _logger.LogError(request.QuoteId, ex.Message, "Exception thrown in Store InstanceId Activity Trigger");
            throw;
        }
    }
}