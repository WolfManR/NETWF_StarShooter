using StarShooter.GameEngine;

namespace StarShooter.Scenes;

public class GameOver : GameScene
{
    public override void Load()
    {
    }

    public override void Draw()
    {
        Drawer.Clear(Color.Black);
        Engine.Stop();
        Drawer.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.Blue, 200, 100);
        Drawer.DrawString($"Your Record: {GameState.PlayerRecord}", new Font(FontFamily.GenericSansSerif, 40, FontStyle.Underline), Brushes.Blue, 150, 190);
    }

    public override void Update()
    {
    }
}