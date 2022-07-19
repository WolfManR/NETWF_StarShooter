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
        LogService.Log("GameProject Work Started");
        try
        {
            Form form = new Form { Width = 800, Height = 600 };
            form.Show();
            form.FormClosing += OnExit;

            Engine.Init(form.CreateGraphics(), form.Width, form.Height);

            LogService.Log("GameEngine Initialized");

            MainGame.Init("Player1", form);

            LogService.Log("MainGame Initialized");

            MainGame.Start();

            Application.Run(form);

            LogService.Log("Application Run");
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

    private static void OnExit(object? sender, FormClosingEventArgs e)
    {
        Engine.Stop();
        LogService.Log("Form Closing");
    }
}