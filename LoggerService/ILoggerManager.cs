namespace ForumApp.LoggerService;

public interface ILoggerManager
{
    void LogInfo(string message);
    void LogWarm(string message);
    void LogDebug(string message);
    void LogError(string message);
}
