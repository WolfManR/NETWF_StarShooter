using StarShooter.GameEngine;

namespace StarShooter.Prefabs;

public class Ship : GameObject, IHealth
{
    public delegate void Message();

    public event Message Died;
    public Image Image { get; set; }
    public RectangleCollider Collider { get; }
    public Point WeaponPos { get => new Point(_position.X + _size.Width, _position.Y + _size.Height / 2); }
    public int Health { get; set; }
    public int Damage { get; }
    public int BaseHealth { get; }
    public bool IsDestroyed { get; private set; } = false;

    public Ship(Point dir, Image image, int health, int damage) : this(new Point(0, 0), dir, new Size(image.Width, image.Height))
    {
        this.Image = image;
        this.Health = health;
        this.BaseHealth = health;
        this.Damage = damage;
    }

    public Ship(Point _position, Point dir, Size _size) : base(_position, dir, _size)
    {
        Collider = new (this);
        Log("Ship created");
    }


    public override void Draw()
    {
        Drawer.DrawImage(Image, _position);
        Log("Ship drawn");
    }
    public override void Update()
    {
    }
    public Bullet Shoot()
    {
        Log("Ship shoot");
        return new Bullet(WeaponPos, 5, this, 3, 8);
    }
    public void MoveUp()
    {
        if (_position.Y > 0) _position.Y -= _direction.Y;
        Log("Ship moved Up");
    }
    public void MoveDown()
    {
        if (_position.Y + _size.Height < Configuration.WindowHeight) _position.Y += _direction.Y;
        Log("Ship moved Down");
    }
    public void DoDamage(object sender, object obj)
    {
        switch (obj)
        {
            case IHealth d:
                Damaged(d, d.Damage);
                d.Damaged(this, Damage);
                break;
            case IBonus b:
                b.Bonus(this);
                break;
        }
        Log($"Ship damage to {obj.GetType().Name} on {Damage} points");
    }
    public void Damaged(object obj, int value)
    {
        if (Health > 0 && Health - value > 0) Health -= value;
        else Died?.Invoke();
        Log($"Ship damaged by {obj.GetType().Name} on {value} points");
    }
    public void Repair(int value)
    {
        Health += value;
        Log($"Ship repaired on {value} points");
    }
}