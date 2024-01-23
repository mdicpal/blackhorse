namespace Domain.Logger
{
    using Microsoft.Extensions.Logging;

    public interface ILoggerAdapter<T>
    {
        void LogInformation(int quoteId, string message, params object[] args);
        void LogInformation(Exception exception,int quoteId, string message, params object[] args);
        void LogWarning(int quoteId, string message, params object[] args);
        void LogWarning(Exception exception,int quoteId, string message, params object[] args);
        void LogError(int quoteId, string message, params object[] args);
        void LogError(Exception exception,int quoteId, string message, params object[] args);
        void LogDebug(int quoteId, string message, in T objT, params object[] args);
        void LogDebug(Exception exception, int quoteId, string message, params object[] args);
        void Log(LogLevel logLevel, int quoteId, string message, params object[] args);
        void Log(LogLevel logLevel, Exception exception, int quoteId, string message, params object[] args);
    }
}