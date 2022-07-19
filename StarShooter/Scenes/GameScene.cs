using StarShooter.GameEngine;

namespace StarShooter.Scenes;

public abstract class GameScene : Scene
{
    public GameState GameState { get; set; }
    public GameObject Player { get; set; }

    protected void DrawPlayerStatusPanel()
    {
        Drawer.DrawString($"Record: {GameState.PlayerRecord}", new Font(FontFamily.GenericSansSerif, 20, FontStyle.Underline), Brushes.White, 200, 10);
        Drawer.DrawString($"Health: {GameState.PlayerHealth}", new Font(FontFamily.GenericSansSerif, 20, FontStyle.Underline), Brushes.White, 10, 10);
    }
}