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

public class StoreApplicationIdActivity
{
    private readonly IInstanceStoreServiceAdapter _instanceStoreServiceAdapter;
    private readonly ILoggerAdapter<StoreApplicationIdActivity> _logger;

    public StoreApplicationIdActivity(IInstanceStoreServiceAdapter instanceStoreServiceAdapter, ILoggerAdapter<StoreApplicationIdActivity> logger)
    {
        _instanceStoreServiceAdapter = instanceStoreServiceAdapter;
        _logger = logger;
    }
        
    [FunctionName(nameof(StoreApplicationIdActivity))]
    public async Task Run([ActivityTrigger] StoreApplicationIdActivityRequest request)
    {
        
        try
        {
            await _instanceStoreServiceAdapter.SetApplicationIdAsync(request.QuoteId, request.InstanceId, request.ApplicationId);
        }
        catch (Exception ex)
        {
            _logger.LogError(request.QuoteId, ex.Message, "Exception thrown in Store ApplicationId Activity Trigger");
            throw;
        }
    }
}