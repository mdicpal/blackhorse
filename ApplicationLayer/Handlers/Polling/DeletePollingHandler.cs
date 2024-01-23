namespace ApplicationLayer.Handlers.Polling;

using ApplicationLayer.Interfaces;
using Interfaces;
using Microsoft.Extensions.Logging;

public class DeletePollingHandler : IDeletePollingHandler
{
    private readonly ILogger<DeletePollingHandler> _logger;
    private readonly IInstanceToPollRepository _repository;

    public DeletePollingHandler(ILogger<DeletePollingHandler> logger, IInstanceToPollRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }
        
    public async Task RunAsync(string applicationId)
    {
        _logger.LogInformation("Deleting instance to poll");
        await _repository.DeleteAsync(applicationId);
        _logger.LogInformation("Deleted instance to poll");
    }
}