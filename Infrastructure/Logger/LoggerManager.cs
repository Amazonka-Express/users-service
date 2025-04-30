using NLog;

namespace Core.Logger
{
    public class LoggerManager : ILoggerManager
    {
        private static readonly ILogger debugLogger = LogManager.GetLogger("debugLogger");
        private static readonly ILogger infoLogger = LogManager.GetLogger("infoLogger");
        private static readonly ILogger warningLogger = LogManager.GetLogger("warningLogger");
        private static readonly ILogger errorLogger = LogManager.GetLogger("errorLogger");

        private static string GetLogString(string methodName, string message) =>
            $"[{methodName}]: {message}";

        public void LogInfo(string message)
        {
            infoLogger.Info(message);
        }

        public void LogWarning(string message)
        {
            warningLogger.Warn(message);
        }

        public void LogError(string message)
        {
            errorLogger.Error(message);
        }

        public void LogDebug(string message)
        {
            debugLogger.Debug(message);
        }

        public void LogInfo(string methodName, string message)
        {
            infoLogger.Info(GetLogString(methodName, message));
        }

        public void LogWarning(string methodName, string message)
        {
            warningLogger.Warn(GetLogString(methodName, message));
        }

        public void LogError(string methodName, string message)
        {
            warningLogger.Error(GetLogString(methodName, message));
        }

        public void LogDebug(string methodName, string message)
        {
            warningLogger.Debug(GetLogString(methodName, message));
        }
    }
}
