using System.Media;
using StarShooter.GameEngine;
using StarShooter.Prefabs;

namespace StarShooter.Scenes;

public class Level1 : GameScene
{
    private static Random Random => Configuration.Random;
    public static int stars = 100;
    public static int asteroids = 6;
    public static int heals = 2;
    
    public List<Bullet> Bullets { get; set; }
    public List<GameObject> Targets { get; set; }
    
    private SystemSound BulletDestroyed = SystemSounds.Hand;
    private SystemSound PlayerDye = SystemSounds.Exclamation;
    private SystemSound AsteroidDestroyed = SystemSounds.Asterisk;

    public override void Load()
    {
        BackgroundObjects = new List<GameObject>();
        Targets = new List<GameObject>();
        GenerateBackground();
        GenerateCollisionObjects();
        Bullets = new List<Bullet>();
        Log("Level 1 loaded");
    }

    public override void Draw()
    {
        Drawer.Clear(Color.Black);

        foreach (GameObject obj in BackgroundObjects) obj.Draw();
        foreach (GameObject obj in Targets) obj.Draw();
        Player.Draw();
        foreach (Bullet obj in Bullets) obj.Draw();

        DrawPlayerStatusPanel();

        Log("Level 1 drawn");
    }

    public override void Update()
    {
        foreach (GameObject obj in BackgroundObjects) obj.Update();
        UpdateCollisionObjects();

        Log("Level 1 updated");
    }

    private void UpdateCollisionObjects()
    {
        bool IsAsteroidsExist = false;
        IHealth playerHealth = (IHealth)Player;

        for (int col = 0; col < Targets.Count; col++)
        {
            Targets[col].Update();
            switch (Targets[col])
            {
                case IHealth d:
                    if (Bullets != null)
                    {
                        for (int bul = 0; bul < Bullets.Count; bul++)
                        {
                            if (Bullets[bul].Collider.IsCollide(d.Collider))
                            {
                                BulletDestroyed.Play();
                                if (Bullets[bul].IsDestroyed) Bullets.RemoveAt(bul--);
                            }
                        }
                    }
                    if (playerHealth.Collider.IsCollide(d.Collider))
                    {
                        PlayerDye.Play();
                    }
                    if (Targets[col] is Asteroid a)
                    {
                        IsAsteroidsExist = true;
                        if (a.IsDestroyed)
                        {

                            GameState.RecordUp(a.RecordPoints);
                            Targets.RemoveAt(col--);
                        }
                    }
                    break;
                case IBonus b:
                    if (playerHealth.Collider.IsCollide(b.Collider))
                    {
                        AsteroidDestroyed.Play();
                    }
                    break;
            }
        }

        if (IsAsteroidsExist == false)
        {
            GenerateAsteroids(++asteroids);
        }

        foreach (var item in Bullets)
        {
            item.Update();
        }
    }

    void GenerateBackground()
    {
        Star.Image = Image.FromFile(Configuration.Assets.Star);
        for (int i = 0; i < stars; i++)
            BackgroundObjects.Add(new Star(new Point(Random.Next(40, Configuration.WindowWidth), Random.Next(0, Configuration.WindowHeight)), new Point(-(15 - Random.Next(2, 8)), 0), new Size(Star.Image.Width, Star.Image.Height)));

        Log("Level 1 background generated");
    }

    void GenerateCollisionObjects()
    {
        GenerateAsteroids(asteroids);
        GenerateHeals(heals);


        Log("Level 1 Collision Objects Generated");
    }

    void GenerateAsteroids(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Image image = Image.FromFile(Configuration.Assets.Asteroid);
            var asteroid = new Asteroid
                           (
                               new Point(Configuration.WindowWidth + image.Width + Random.Next(40, 300), Random.Next(70, Configuration.WindowHeight - 120)),
                               new Point(-(15 - Random.Next(2, 10)), 0),
                               new Size(image.Width, image.Height),
                               3,
                               14,
                               18
                           )
            {
                Image = image
            };
            Targets.Add(asteroid);
        }

        Log("Level 1 asteroids generated");
    }
    void GenerateHeals(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Image image = Image.FromFile(Configuration.Assets.Heal);
            var heal = new Heal
                       (
                           new Point(Random.Next(380, Configuration.WindowWidth), Random.Next(70, Configuration.WindowHeight - 120)),
                           new Point(-(15 - Random.Next(2, 4)), 0),
                           new Size(image.Width, image.Height),
                           30
                       )
            {
                Image = image
            };
            Targets.Add(heal);
        }

        Log("Level 1 heals generated");
    }
}