namespace ApplicationLayer.Handlers.Polling;

using ApplicationLayer.Interfaces;
using ApplicationLayer.Models;
using Interfaces;
using Microsoft.Extensions.Logging;
using Models;

public class UpsertPollingHandler : IUpsertPollingHandler
{
    private readonly ILogger<UpsertPollingHandler> _logger;
    private readonly IInstanceToPollRepository _repository;
    private readonly IInstanceToPollDtoMapper _mapper;

    public UpsertPollingHandler(ILogger<UpsertPollingHandler> logger, IInstanceToPollRepository repository, IInstanceToPollDtoMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }
        
    public async Task RunAsync(UpsertRequest request)
    {
        _logger.LogInformation(request.QuoteId, "Adding instance to poll");
        InstanceToPollDto instanceDto = _mapper.Map(request);
        await _repository.UpsertAsync(instanceDto);
        _logger.LogInformation(request.QuoteId,"Added instance to poll");
    }
}