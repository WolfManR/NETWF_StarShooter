using StarShooter.GameEngine;
using StarShooter.Prefabs;
using StarShooter.Scenes;

namespace StarShooter;

public class PlayerBehaviorManager
{
    public static void Attack()
    {
        if (GetLevelScene() is not {} levelScene) return;
        levelScene.Bullets.Add(levelScene.Player.Shoot());
    }

    public static void MoveUp()
    {
        GetScenePlayer()?.MoveUp();
    }

    public static void MoveDown()
    {
        GetScenePlayer()?.MoveDown();
    }

    private static Level1? GetLevelScene()
    {
        return Engine.Scene as Level1;
    }

    private static Ship? GetScenePlayer()
    {
        if (GetLevelScene() is not { } levelScene) return null;
        return levelScene.Player;
    }
}