namespace ApplicationLayer.Handlers.Polling.Interfaces;

using Models;

public interface IUpsertPollingHandler
{
    Task RunAsync(UpsertRequest request);
}