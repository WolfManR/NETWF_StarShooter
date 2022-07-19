using System.Drawing;

namespace StarShooter.GameEngine;

public static class Engine
{
    private static BufferedGraphicsContext context;
    public static BufferedGraphics buffer;
    public static Graphics TargetGraphics => buffer.Graphics;
    public static int Width { get; set; }
    public static int Height { get; set; }
    public static Timer Timer { get; } = new Timer { Interval = 100 };
    public static Scene Scene { get; set; }

    public static void Init(Graphics targetGraphics, int width, int height)
    {
        Width = width;
        Height = height;
        //if (width > 1000 || height > 1000 || width < 0 || height < 0) throw new ArgumentOutOfRangeException("Width or Heigth <0 or >1000");

        // предоставляет доступ к главному буферу графического контекста для текущего приложения
        context = BufferedGraphicsManager.Current;
        // Связываем буфер в памяти с графическим объектом, для того, чтобы рисовать в буфере
        buffer = context.Allocate(targetGraphics, new Rectangle(0, 0, Width, Height));

        Timer.Tick += (_, _) =>
        {
            Scene.Draw();
            buffer.Render();
            Scene.Update();
        };
    }

    public static void Start()
    {
        Scene.Load();
        Timer.Start();
    }

    public static void Render()
    {
        buffer.Render();
    }

    public static void Stop()
    {
        Timer.Stop();
    }
}