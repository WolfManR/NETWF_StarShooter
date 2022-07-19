using StarShooter.GameEngine;

using System.Numerics;

namespace StarShooter.Prefabs;

public class Bullet : GameObject, IHealth
{
    private readonly int _speed;

    public Bullet(Point pos, int speed, GameObject player, int health, int damage) : this(pos, new Point(speed, 0), new Size(4, 2))
    {
        this.Player = player;
        this._speed = speed;
        this.Health = health;
        this.BaseHealth = health;
        this.Damage = damage;
    }
    public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
    {
        Collider = new(this);
        _speed = dir.X;

        Log("Bullet created");
    }

    public GameObject Player { get; set; }
    public RectangleCollider Collider { get; }
    public int Health { get; set; }
    public int Damage { get; }
    public int BaseHealth { get; }
    public bool IsDestroyed { get; private set; }
    public bool FriendlyFire { get; set; }

    public override void Draw()
    {
        Drawer.DrawRectangle(Pens.Red, _position.X, _position.Y, _size.Width, _size.Height);
        Log("Bullet drawn");
    }

    public override void Update()
    {
        if (_position.X < Configuration.WindowWidth + _size.Width) _position.X += _speed;

        Log("Bullet updated");
    }

    public void Damaged(object other, int value)
    {
        if(!(ReferenceEquals(Player, other) && FriendlyFire)) return;

        if (Health > 0 && Health - value > 0) Health -= value;
        else IsDestroyed = true;

        Log($"Bullet damaged by {other.GetType().Name} on {value} points");
    }
}