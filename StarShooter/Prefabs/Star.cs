using StarShooter.GameEngine;

namespace StarShooter.Prefabs;

public class Star : GameObject
{
    public static Image Image { get; set; }

    public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
    {
        Log("Star created");
    }
    
    public override void Draw()
    {
        Drawer.DrawImage(Image, _position);

        Log("Star drawn");
    }

    public override void Update()
    {
        _position.X += _direction.X;
        if (_position.X < 0) _position.X = Configuration.WindowWidth + 20;

        Log("Star updated");
    }
}