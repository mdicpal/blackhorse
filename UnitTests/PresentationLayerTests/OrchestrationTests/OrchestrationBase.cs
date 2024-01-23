namespace UnitTests.PresentationLayerTests.OrchestrationTests;

using ApplicationLayer.Handlers.Config.Models;
using ApplicationLayer.Handlers.MakeApplication.Models;
using AzureFunderCommonMessages.DotNet.Request;
using AzureFunderCommonMessages.DotNet.Response;
using AzureFunderCommonMessages.DotNet.Types;
using Domain.Logger;
using global::Orchestrator.Activities;
using global::Orchestrator.Activities.Application;
using global::Orchestrator.Activities.Config;
using global::Orchestrator.Orchestrator_1_0;
using Helpers;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using Moq;

public abstract class OrchestrationBase
{
    protected Mock<IDurableOrchestrationContext> Context = null!;
    protected OrchestratorV1_0 Orchestrator = null!;
    protected ApplicationRequest Application = null!;

    [SetUp]
    public void Setup()
    {
        Context = new Mock<IDurableOrchestrationContext>();
        Orchestrator = new OrchestratorV1_0(new Mock<ILoggerAdapter<OrchestratorV1_0>>().Object);
        SetupActivity(nameof(GetConfigActivity), new OrchestrationConfig() { ExpirationTimoutInDays = -10 });
        Application = ApplicationFaker.Build();
        Context.Setup(x => x.GetInput<ApplicationRequest>()).Returns(Application);
    }

    protected void ContextSetupPreEventLoop(StatusResponseType status = StatusResponseType.ApplicationWithFunder)
    {
        SetupActivity(nameof(MakeApplicationActivity), new MakeApplicationActivityResponse
        {
            Success = true,
            ApplicationId = "ApplicationId",
            CommonResponses = { new CommonResponse() }
        });
    }

    protected void SetupActivityThrows(string functionName, Exception exception)
    {
        Context
            .Setup(x => x.CallActivityWithRetryAsync(functionName, It.IsAny<RetryOptions>(),It.IsAny<object>()))
            .ThrowsAsync(exception);
    }

    protected void SetupActivityThrows<TResult>(string functionName, Exception exception)
    {
        Context
            .Setup(x => x.CallActivityWithRetryAsync<TResult>(functionName, It.IsAny<RetryOptions>(),It.IsAny<object>()))
            .ThrowsAsync(exception);
    }

    protected void SetupActivity<TResult>(string functionName, TResult result)
    {
        Context
            .Setup(x => x.CallActivityWithRetryAsync<TResult>(functionName, It.IsAny<RetryOptions>(),It.IsAny<object>()))
            .ReturnsAsync(result);
    }

    protected void SetupActivity(string functionName)
    {
        Context
            .Setup(x => x.CallActivityWithRetryAsync(functionName, It.IsAny<RetryOptions>(), It.IsAny<object>()));
    }

    protected void VerifyActivity(string name, object dto, Func<Times>? times = null)
    {
        times ??= Times.AtLeastOnce;
        Context.Verify(
            x => x.CallActivityWithRetryAsync(nameof(SendToServiceBusActivity), It.IsAny<RetryOptions>(), dto),
            times);
    }

    protected void VerifyActivity(string name, Func<Times>? times = null)
    {
        times ??= Times.AtLeastOnce;
        Context.Verify(x => x.CallActivityWithRetryAsync(name, It.IsAny<RetryOptions>(), It.IsAny<object>()), times);
    }

    protected void VerifyActivity<T>(string name, Func<Times>? times = null)
    {
        times ??= Times.AtLeastOnce;
        Context.Verify(x => x.CallActivityWithRetryAsync<T>(name, It.IsAny<RetryOptions>(), It.IsAny<object>()), times);
    }

    protected void VerifyActivity<T>(string name, Times times)
    {
        Context.Verify(x => x.CallActivityWithRetryAsync<T>(name, It.IsAny<RetryOptions>(), It.IsAny<object>()), times);
    }
}