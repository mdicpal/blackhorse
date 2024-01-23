namespace ApplicationLayer.Handlers.FunderUpdates;

using AzureFunderCommonMessages.DotNet.Types;
using FunderApi;
using FunderService.Mappers;
using Interfaces;
using Microsoft.Extensions.Logging;
using Models;

public class FunderUpdateHandler : IFunderUpdateHandler
{
    private readonly ILogger<FunderUpdateHandler> _logger;
    private readonly IFunderUpdateSuccessResponseMapper _successResponseMapper;

    public FunderUpdateHandler(
        ILogger<FunderUpdateHandler> logger,
        IFunderUpdateSuccessResponseMapper successResponseMapper
    )
    {
        _logger = logger;
        _successResponseMapper = successResponseMapper;
    }
    
    public FunderUpdateResponse Run(ApplicationStatusResponse applicationStatusResponse)
    {
        _logger.LogInformation(applicationStatusResponse.QuoteId, "Processing application update for quote");
        DecisionStatus decisionStatus = applicationStatusResponse.StatusUpdate.Decision_status;
        StatusResponseType applicationStatus = FunderStatusMapper.Map(decisionStatus);
        List<string> conditions = applicationStatusResponse.StatusUpdate?.Condition!=null? applicationStatusResponse.StatusUpdate.Condition.ToList<string>():null;
        return _successResponseMapper.Map(applicationStatusResponse, applicationStatus, conditions);
    }
}