using StarShooter.GameEngine;

namespace StarShooter.Prefabs;

public class Asteroid : GameObject, IHealth
{
    public Image Image { get; set; }
    public RectangleCollider Collider { get; }
    public int RecordPoints { get; }
    public int Health { get; set; }
    public int Damage { get; }
    public int BaseHealth { get; }
    public bool IsDestroyed { get; private set; } = false;

    public Asteroid(Point pos, Point dir, Size size, int recordPoints, int health, int damage) : base(pos, dir, size)
    {
        Collider = new(this);
        this.Health = health;
        this.BaseHealth = health;
        this.Damage = damage;
        this.RecordPoints = recordPoints;

        Log("Asteroid created");
    }

    public override void Draw()
    {
        Drawer.DrawImage(Image, _position);

        Log("Asteroid drawn");
    }
    public override void Update()
    {
        _position.X += _direction.X;
        if (_position.X < 0) _position.X = Configuration.WindowWidth + 20;

        Log("Asteroid updated");
    }
    public void ResetPos()
    {
        _position.X = Configuration.WindowWidth;

        Log("Asteroid reset position");
    }

    public void Damaged(object obj, int value)
    {
        if (Health > 0 && Health - value > 0) Health -= value;
        else
        {
            IsDestroyed = true;
        }

        Log($"Asteroid damaged by {obj.GetType().Name} on {value} points");
    }
}