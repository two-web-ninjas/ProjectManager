using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.Logging;
using ProjectManager.Core.Interface;

namespace ProjectManager.Infrastructure
{
    public class LoggerAdapter<T> : ILoggerAdapter<T>
    {
        private readonly ILogger<T> _logger;

        public LoggerAdapter(ILogger<T> logger)
        {
            _logger = logger;
        }

        private string GetMessageFormat(string message)
        {
            var st = new StackTrace();

            return $"[{typeof(T).FullName}.{st.GetFrame(2).GetMethod().Name}] {message}";
        }

        public void LogError(Exception ex, string message, params object[] args)
        {
            _logger.LogError(ex, GetMessageFormat(message), args);
        }

        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(GetMessageFormat(message), args);
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(GetMessageFormat(message), args);
        }
    }
}
