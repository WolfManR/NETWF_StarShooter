namespace StarShooter.GameEngine;

public class Timer
{
    private System.Threading.Timer? _timer;

    public int Interval { get; set; } = 1000;

    public event EventHandler<EventArgs>? Tick;

    public void Start()
    {
        _timer = new(_ => { Tick?.Invoke(null, EventArgs.Empty); }, null, 0, Interval);
    }

    public void Stop()
    {
        _timer?.Dispose();
    }
}