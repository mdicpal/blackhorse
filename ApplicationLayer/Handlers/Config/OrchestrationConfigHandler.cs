namespace ApplicationLayer.Handlers.Config
{
    using Interfaces;
    using Microsoft.Extensions.Logging;
    using Models;

    public class OrchestrationConfigHandler : IOrchestrationConfigHandler
    {
        private readonly ILogger<OrchestrationConfigHandler> _logger;

        public OrchestrationConfigHandler(ILogger<OrchestrationConfigHandler> logger)
        {
            _logger = logger;
        }
        public OrchestrationConfig Run()
        {
            _logger.LogInformation("Getting config for orchestrator");
            return new OrchestrationConfig()
            {
                ExpirationTimoutInDays = 14
            };
        }
    }
}