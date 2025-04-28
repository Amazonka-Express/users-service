namespace Core.Logger
{
    public interface ILoggerManager
    {
        void LogInfo(string message);
        void LogInfo(string methodName, string message);
        void LogWarning(string message);
        void LogWarning(string methodName, string message);
        void LogError(string message);
        void LogError(string methodName, string message);
        void LogDebug(string message);
        void LogDebug(string methodName, string message);
    }
}
