namespace Orchestrator;

using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using System;

public static class RetryOptionsBuilder
{
    public static RetryOptions GetRetryOptions(int milliseconds = 20000, int maxAttempts = 10)
    {
        return new RetryOptions(TimeSpan.FromMilliseconds(milliseconds), maxAttempts);
    }
}