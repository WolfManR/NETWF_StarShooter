using System.Drawing;

namespace StarShooter.GameEngine;

public abstract class Scene
{
    public List<GameObject> BackgroundObjects { get; set; }


    public static void Test()
    {
        // Проверяем вывод графики
        Engine.buffer.Graphics.Clear(Color.Black);
        Engine.buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
        Engine.buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
    }

    public abstract void Load();
    public abstract void Draw();
    public abstract void Update();
}