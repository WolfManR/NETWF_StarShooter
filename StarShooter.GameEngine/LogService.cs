namespace StarShooter.GameEngine;

public class LogService : IDisposable
{
    private static event Action<string>? OnLog;
    private static readonly List<Logger> Loggers = new();

    public void Initialize(IReadOnlyCollection<Logger> loggers)
    {
        Loggers.AddRange(loggers);
        foreach (var logger in loggers)
            OnLog += logger.Log;
    }

    public static void Log(string message)
    {
        OnLog?.Invoke(message);
    }

    public void Dispose()
    {
        foreach (var logger in Loggers) OnLog -= logger.Log;
    }
}