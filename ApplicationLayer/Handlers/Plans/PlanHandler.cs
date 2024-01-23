namespace ApplicationLayer.Handlers.Plans
{
    using FunderApi;
    using FunderService.Interfaces;
    using Interfaces;
    using Microsoft.Extensions.Logging;
    using Models;

    internal class PlanHandler : IPlanHandler
    {
       
        private readonly IFunderClient _funderClient;
        private readonly ILogger<PlanHandler> _logger;

        public PlanHandler(
            IFunderClient funderClient,
            ILogger<PlanHandler> logger)
        {
            _funderClient = funderClient;
            _logger = logger;
        }
        public async Task<GetPlanResponse> Run(int planId)
        {
            int majorDealerId = Convert.ToInt32(Environment.GetEnvironmentVariable("x-lbg-major-dealerId"));
            int minorDealerId = Convert.ToInt32(Environment.GetEnvironmentVariable("x-lbg-minor-dealerId"));
            try
            {
                return await _funderClient.GetPlansAsync(majorDealerId,minorDealerId,planId);   
            }
            catch (Exception e)
            {
                _logger.LogError(e,"Failed to get plans");
                throw; 
            }
        }
    }
}