namespace Orchestrator.Exceptions;

using System;
using System.Runtime.Serialization;

[Serializable]
public class InvalidOrchestrationException : Exception
{
    public InvalidOrchestrationException()
    {
    }

    public InvalidOrchestrationException(string message)
        : base(message)
    {
    }

    public InvalidOrchestrationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
    protected InvalidOrchestrationException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}