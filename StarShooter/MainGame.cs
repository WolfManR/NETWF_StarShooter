using StarShooter.GameEngine;
using StarShooter.Prefabs;
using StarShooter.Scenes;

namespace StarShooter;

public class MainGame
{
    private static Ship _player;

    public static GameState State { get; set; }
    private static Level1 _scene;

    public static void Init(string playerName)
    {
        _scene = new();
        State = new GameState(100) { CurrentScene = _scene };

        var player = new Ship(new Point(4, Configuration.WindowHeight / 2), Image.FromFile(Configuration.Assets.Ship), State.PlayerHealth, 40);
        player.Died += State.GameOver;
        _player = player;

        State.CurrentScene.Load();
        State.CurrentScene.Player = player;
    }

    public static void Start()
    {
        Engine.Scene = State.CurrentScene;
        Engine.Play();
    }

    public static void Attack()
    {
        _scene.Bullets.Add(_player.Shoot());
    }

    public static void MoveUp()
    {
        _player.MoveUp();
    }

    public static void MoveDown()
    {
        _player.MoveDown();
    }
}