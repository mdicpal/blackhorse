namespace Orchestrator.Timers
{
    using DurableTask.Core;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.DurableTask;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CleanupTimer
    {
        private readonly ILogger<CleanupTimer> _logger;

        public CleanupTimer(ILogger<CleanupTimer> logger)
        {
            _logger = logger;
        }
        [FunctionName(nameof(CleanupTimer))]
        public async Task Run([TimerTrigger("0 0 0 * * *")] TimerInfo myTimer,
            [DurableClient] IDurableOrchestrationClient orchestrationClient, ILogger log)
        {
            try
            {
                DateTime createdTimeFrom = DateTime.UtcNow.Subtract(TimeSpan.FromDays(120));
                DateTime createdTimeTo = createdTimeFrom.AddDays(30);
                List<OrchestrationStatus> runtimeStatus = new List<OrchestrationStatus>
                {
                    OrchestrationStatus.Completed,
                    OrchestrationStatus.Failed,
                    OrchestrationStatus.Terminated,
                    OrchestrationStatus.Canceled
                };
                PurgeHistoryResult result = await orchestrationClient.PurgeInstanceHistoryAsync(createdTimeFrom, createdTimeTo, runtimeStatus);
                _logger.LogInformation("Scheduled cleanup done, {InstancesDeleted} instances deleted", result.InstancesDeleted);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Exception thrown in CleanupTimer Trigger");
                throw;
            }
        }
    }
}