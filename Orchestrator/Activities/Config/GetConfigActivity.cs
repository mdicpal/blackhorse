namespace Orchestrator.Activities.Config
{
    using ApplicationLayer.Handlers.Config.Interfaces;
    using ApplicationLayer.Handlers.Config.Models;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.DurableTask;
    using Microsoft.Extensions.Logging;
    using System;

    public class GetConfigActivity
    {
        private readonly ILogger<GetConfigActivity> _logger;
        private readonly IOrchestrationConfigHandler _handler;

        public GetConfigActivity(ILogger<GetConfigActivity> logger, IOrchestrationConfigHandler handler)
        {
            _logger = logger;
            _handler = handler;
        }
        
        /*
         * <summary>
         * Delegating this responsibility to the Application layer
         * </summary>
         */
        [FunctionName(nameof(GetConfigActivity))]
        public OrchestrationConfig Run([ActivityTrigger] int requiredParameter)
        {
            try
            {
                _logger.LogInformation("Getting config");
                return _handler.Run();
            }
            catch(Exception e)
            {
                _logger.LogError(e, "Failed to get config data");
                throw;
            }
        } 
    }
}