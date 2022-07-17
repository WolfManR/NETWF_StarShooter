using StarShooter.GameEngine;
using StarShooter.Loggers;

namespace StarShooter;

class Program
{
    private static readonly LogService Logger;

    private static readonly IReadOnlyCollection<Logger> Loggers = new Logger[]
    {
        new ConsoleLogger(),
        new FileLogger("Log.txt")
    };

    static Program()
    {
        Logger = new();
        Logger.Initialize(Loggers);
    }

    [STAThread]
    static void Main()
    {
        try
        {

        }
        catch (Exception ex)
        {
            LogService.Log(ex.Message);
        }
        finally
        {
            Logger.Dispose();
            var disposableLoggers = Loggers.OfType<IDisposable>().ToList();
            foreach (var disposable in disposableLoggers) disposable.Dispose();
        }
    }
}