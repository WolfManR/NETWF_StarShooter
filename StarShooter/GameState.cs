using StarShooter.GameEngine;
using StarShooter.Prefabs;
using StarShooter.Scenes;

namespace StarShooter;

public class GameState
{
    public int PlayerRecord { get; private set; }
    public int PlayerHealth { get; private set; }

    private Queue<Keys> _inputQueue = new();

    public GameState(int playerHealth)
    {
        PlayerHealth = playerHealth;
    }

    public GameScene CurrentScene
    {
        set
        {
            value.GameState = this;
            Engine.Scene = value;
        }
    }

    public Ship Player { get; set; }

    public void RecordUp(int count)
    {
        PlayerRecord += count;

        LogService.Log($"Record Up on {count} points");
    }

    public void LoadLevel1()
    {
        CurrentScene = new Level1();
    }

    public void LoadGameOver()
    {
        CurrentScene = new GameOver();
    }
}