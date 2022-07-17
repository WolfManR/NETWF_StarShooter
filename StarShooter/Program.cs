using StarShooter.Loggers;

namespace StarShooter;

class Program
{
    private static event Log OnLog;

    private static readonly IReadOnlyCollection<Logger> Loggers = new Logger[]
    {
        new ConsoleLogger(),
        new FileLogger("Log.txt")
    };

    static Program()
    {
        foreach (var logger in Loggers)
            OnLog += logger.Log;
    }

    [STAThread]
    static void Main()
    {
        try
        {

        }
        catch (Exception ex)
        {
            OnLog.Invoke(ex.Message);
        }
        finally
        {
            var disposableLoggers = Loggers.OfType<IDisposable>().ToList();

            foreach (var logger in Loggers) OnLog -= logger.Log;

            foreach (var disposable in disposableLoggers) disposable.Dispose();
        }
    }
}