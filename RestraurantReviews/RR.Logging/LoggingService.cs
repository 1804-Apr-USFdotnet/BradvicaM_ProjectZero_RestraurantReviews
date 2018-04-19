using System;
using NLog;
using RR.DomainContracts;

namespace RR.Logging
{
    class LoggingService : ILoggingService
    {
        private readonly ILogger _logger;

        public LoggingService(ILogger logger)
        {
            _logger = logger;
        }

        public void Log(Exception e)
        {
            _logger.Log(LogLevel.Info, e);
        }
    }
}
