namespace InstanceStoreAdapter;

using ApplicationLayer.Models;
using InstanceStoreService.Interfaces;
using Interfaces;

public class InstanceStoreServiceAdapter : IInstanceStoreServiceAdapter
{
    private readonly IGetOrchestration _getter;
    private readonly IPutOrchestration _putter;

    public InstanceStoreServiceAdapter(IGetOrchestration getter, IPutOrchestration putter)
    {
        _getter = getter;
        _putter = putter;
    }

    public async Task CreateAsync(int quoteId, string instanceId) =>
        await _putter.CreateAsync(quoteId, instanceId);

    public async Task SetApplicationIdAsync(int quoteId, string instanceId, string applicationId) =>
        await _putter.UpdateFunderReferenceAsync(quoteId, instanceId, applicationId);

    public async Task<Instance> GetAsync(int quoteId)
    {
        var instance = await _getter.GetAsync(quoteId);
        if (instance is null) return null;
        
        return new Instance()
        {
            ApplicationId = instance.ApplicationId,
            QuoteId = (int)instance.QuoteId!,
            Status = instance.Status,
            Id = instance.InstanceId
        };
    }

}