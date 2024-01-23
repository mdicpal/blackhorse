namespace ApplicationLayer.Handlers.Polling;

using ApplicationLayer.Models;
using Extensions;
using FunderService.Interfaces;
using Interfaces;

public class PollingHandler : IPollingHandler
{
    private readonly IFunderClient _funderClient;

    public PollingHandler(IFunderClient funderClient)
    {
        _funderClient = funderClient;
    }
        
    public async Task<FunderUpdate> RunAsync(InstanceToPollDto instance)
    {
        int majorDealerId = Convert.ToInt32(Environment.GetEnvironmentVariable("x-lbg-major-dealerId"));
        int minorDealerId = Convert.ToInt32(Environment.GetEnvironmentVariable("x-lbg-minor-dealerId"));
        var response = await _funderClient.GetApplicationStatusAsync(majorDealerId,minorDealerId,instance.CustomerId, instance.ProposalId);
        var hash = response.ToDeterministicHash();
        return new FunderUpdate
        {
            FunderResponse = response,
            HasChanged = hash != instance.DeterministicHash,
            InstanceId = instance.InstanceId
        };
    }
}