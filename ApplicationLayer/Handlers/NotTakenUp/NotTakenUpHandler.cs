namespace ApplicationLayer.Handlers.NotTakenUp;

using FunderApi;
using FunderService.Interfaces;
using FunderService.Mappers.Interfaces;
using Interfaces;
using Microsoft.Extensions.Logging;
using Models;

public class NotTakenUpHandler : INotTakenUpHandler
{
   
    private readonly INotTakenUpActivitySuccessResponseMapper _successResponseMapper;
    private readonly INotTakenUpActivityFailedResponseMapper _failedResponseMapper;
    private readonly IFunderClient _funderClient;
    private readonly ILogger<NotTakenUpHandler> _logger;

    public NotTakenUpHandler(
        IFunderClient funderClient,
        INotTakenUpActivitySuccessResponseMapper successResponseMapper, 
        INotTakenUpActivityFailedResponseMapper failedResponseMapper, 
        ILogger<NotTakenUpHandler> logger)
    {
        _funderClient = funderClient;
        _successResponseMapper = successResponseMapper;
        _failedResponseMapper = failedResponseMapper;
        _logger = logger;
    }

    public async Task<NotTakenUpActivityResponse> Run(NotTakenUpActivityRequest request)
    {
        NotTakenUpResponse funderResponse = null;
        int majorDealerId = Convert.ToInt32(Environment.GetEnvironmentVariable("x-lbg-major-dealerId"));
        int minorDealerId = Convert.ToInt32(Environment.GetEnvironmentVariable("x-lbg-minor-dealerId"));
        string idempotency = DateTime.Now.ToString("yyyymmddhhmmss");
        try
        {          
            funderResponse = await _funderClient.NotTakenUpAsync(majorDealerId,minorDealerId,idempotency,Convert.ToInt32(request?.CustomerId), (Convert.ToInt32(request?.ProposalId)));
            return _successResponseMapper.Map(request.ApplicationRequest.QuoteId, request.CustomerId,request.ProposalId, funderResponse);
        }
        catch (Exception e)
        {
            _logger.LogInformation(e, "Exception returned, {Errors}", e.Message);
            return _failedResponseMapper.Map(request.ApplicationRequest.QuoteId, request.CustomerId,request.ProposalId, funderResponse, e);
        }    
    }
}