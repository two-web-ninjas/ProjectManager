using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Core.Interface
{
    public interface ILoggerAdapter<T>
    {
        void LogInformation(string message, params object[] args);
        void LogError(Exception ex, string message, params object[] args);
        void LogWarning(string message, params object[] args);
    }
}
