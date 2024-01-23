namespace Orchestrator.Adapters
{
    using Domain.Logger;
    using Microsoft.Extensions.Logging;
    using System;

    public class LoggerAdapter<T> : ILoggerAdapter<T>
    {
        private readonly ILogger<T> _logger;
        private readonly string _funderCode;

        public LoggerAdapter(ILogger<T> logger)
        {
            _logger = logger;
            _funderCode = Startup.FunderCode; //I dont like this :D
        }

        public void LogInformation(int quoteId, string message, params object[] args)
            => Log(LogLevel.Information, quoteId, message, args);

        public void LogInformation(Exception exception,int quoteId, string message, params object[] args)
            => Log(LogLevel.Information, exception, quoteId, message, args);

        public void LogWarning(int quoteId, string message, params object[] args)
            => Log(LogLevel.Warning, quoteId, message, args);

        public void LogWarning(Exception exception,int quoteId, string message, params object[] args)
            => Log(LogLevel.Warning, exception, quoteId, message, args);

        public void LogError(int quoteId, string message, params object[] args)
            => Log(LogLevel.Error, quoteId, message, args);

        public void LogError(Exception exception,int quoteId, string message, params object[] args)
            => Log(LogLevel.Error, exception, quoteId, message, args);

        public void LogDebug(int quoteId, string message,in T objT, params object[] args)
            => Log(LogLevel.Debug, quoteId, message, args);

        public void LogDebug(Exception exception, int quoteId, string message, params object[] args)
            => Log(LogLevel.Debug, exception, quoteId, message, args);
        public void Log(LogLevel logLevel, int quoteId, string message, params object[] args)
        {
            string inputMessage = string.Format(message, args);
            _logger.Log(logLevel, "Quote: {QuoteId}, Funder: {FunderCode} {InputMessage}", quoteId, _funderCode, inputMessage);
        }
        public void Log(LogLevel logLevel, Exception exception, int quoteId, string message, params object[] args)
        {
            string inputMessage = string.Format(message, args);
            _logger.Log(logLevel, exception, "Quote: {QuoteId}, Funder: {FunderCode} {InputMessage}", quoteId, _funderCode, inputMessage);
        }
    }
}