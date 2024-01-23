namespace ApplicationLayer.Handlers.Polling.Interfaces
{
    public interface IDeletePollingHandler
    {
        Task RunAsync(string applicationId);
    }
}