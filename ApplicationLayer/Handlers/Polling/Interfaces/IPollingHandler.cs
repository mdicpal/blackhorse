namespace ApplicationLayer.Handlers.Polling.Interfaces;

using ApplicationLayer.Models;

public interface IPollingHandler
{
    Task<FunderUpdate> RunAsync(InstanceToPollDto instance);
}