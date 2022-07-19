using StarShooter.GameEngine;

namespace StarShooter.Prefabs;

public class Heal : GameObject, IBonus
{
    readonly int healPoints;
    public Image Image { get; set; }
    public RectangleCollider Collider { get; }

    public Heal(Point pos, Point dir, Size size, int healPoints) : base(pos, dir, size)
    {
        Collider = new(this);
        this.healPoints = healPoints;

        Log("Heal created");
    }
    public override void Draw()
    {
        Drawer.DrawImage(Image, _position);

        Log("Heal drawn");
    }

    public void ResetPos()
    {
        _position.X = Configuration.WindowWidth;

        Log("Heal reset position");
    }

    public override void Update()
    {
        _position.X += _direction.X;
        if (_position.X < 0) _position.X = Configuration.WindowWidth + 20;

        Log("Heal updated");
    }

    public void Bonus(IHealth ship)
    {
        if (ship.Health < ship.BaseHealth && ship.Health + healPoints < ship.BaseHealth)
        {
            ship.Health += healPoints;
        }
        else if (ship.Health + healPoints > ship.BaseHealth)
        {
            ship.Health += ship.BaseHealth - ship.Health;
        }
        ResetPos();

        Log($"Heal bonus given to {ship.GetType().Name}");
    }
}