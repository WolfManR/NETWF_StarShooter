using StarShooter.GameEngine;
using StarShooter.Prefabs;

namespace StarShooter;

public class MainGame
{
    public static GameState State { get; set; }

    public static void Init(string playerName, Form mainForm)
    {
        State = new GameState(100, mainForm);

        var player = new Ship(new Point(4, Configuration.WindowHeight / 2), Image.FromFile(Configuration.Assets.Ship), State.PlayerHealth, 40);
        player.Died += GameOver;

        State.Player = player;
    }

    public static void Start()
    {
        State.MainForm.KeyDown += Form_KeyDown;
        State.LoadLevel1();
        Engine.Start();
    }

    public static void GameOver()
    {
        Engine.Stop();
        State.LoadGameOver();
        Engine.Start();
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