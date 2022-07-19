using StarShooter.GameEngine;
using StarShooter.Scenes;

namespace StarShooter;

public class GameState
{
    private GameScene _currentScene;
    public int PlayerRecord { get; private set; }
    public int PlayerHealth { get; private set; }

    public GameState(int playerHealth)
    {
        PlayerHealth = playerHealth;
    }

    public GameScene CurrentScene
    {
        get => _currentScene;
        set
        {
            _currentScene = value;
            value.GameState = this;
        }
    }

    private Graphics Drawer => Engine.TargetGraphics;

    public void RecordUp(int count)
    {
        PlayerRecord += count;

        LogService.Log($"Record Up on {count} points");
    }

    public void GameOver()
    {
        Engine.Timer.Stop();
        Drawer.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.Blue, 200, 100);
        Drawer.DrawString($"Your Record: {PlayerRecord}", new Font(FontFamily.GenericSansSerif, 40, FontStyle.Underline), Brushes.Blue, 150, 190);
        Engine.Render();
    }
}