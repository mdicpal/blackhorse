namespace Orchestrator.Triggers.Interfaces;

using AzureFunderCommonMessages.DotNet.Request;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using System.Threading.Tasks;

public interface INewApplicationTrigger
{
    Task RunAsync(IDurableOrchestrationClient starter, ApplicationRequest request);
}