using StarShooter.GameEngine;

namespace StarShooter.Loggers;

public class FileLogger : Logger, IDisposable
{
    private readonly string _filePath;
    private StreamWriter? _writer;

    public FileLogger(string filePath)
    {
        _filePath = filePath;
    }

    public override void Log(string message)
    {
        _writer ??= new StreamWriter(_filePath);
        _writer.WriteLine(message);
        _writer.Flush();
    }

    public void Dispose()
    {
        _writer?.Dispose();
    }
}