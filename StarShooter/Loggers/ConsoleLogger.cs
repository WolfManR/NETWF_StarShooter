using StarShooter.GameEngine;

namespace StarShooter.Loggers;

public class ConsoleLogger : Logger
{
    public override void Log(string message)
    {
        Console.WriteLine(message);
    }
}