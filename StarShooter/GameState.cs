using StarShooter.GameEngine;
using StarShooter.Prefabs;
using StarShooter.Scenes;

namespace StarShooter;

public class GameState
{
    public int PlayerRecord { get; private set; }
    public int PlayerHealth { get; private set; }
    public Form MainForm { get; }

    public GameState(int playerHealth, Form mainForm)
    {
        PlayerHealth = playerHealth;
        MainForm = mainForm;
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
        MainForm.Controls.Clear();
        MainForm.BackgroundImage = null;
        var level1 = new Level1()
        {
            Player = Player
        };
        CurrentScene = level1;
        MainForm.KeyDown += Form_KeyDown;
        Engine.Start();
    }

    public void LoadGameOver()
    {
        CurrentScene = new GameOver();
    }

    public void LoadSplashScreen()
    {
        var splashScreen = new SplashScreen();
        CurrentScene = splashScreen;
        splashScreen.OnExit += MainForm.Close;
        splashScreen.OnStartGame += LoadLevel1;
    }


    private static void Form_KeyDown(object? sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.ControlKey:
                PlayerBehaviorManager.Attack();
                break;
            case Keys.Up:
                PlayerBehaviorManager.MoveUp();
                break;
            case Keys.Down:
                PlayerBehaviorManager.MoveDown();
                break;
        }
    }
}