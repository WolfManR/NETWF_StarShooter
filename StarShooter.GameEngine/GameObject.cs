using System.Drawing;

namespace StarShooter.GameEngine;

public abstract class GameObject
{
    protected Point _position = new();
    protected Point _direction = new();
    protected Size _size = new();

    protected GameObject() { }

    protected GameObject(Point position, Point direction, Size size)
    {
        _position = position;
        _direction = direction;
        _size = size;
    }

    protected Graphics Drawer => Engine.TargetGraphics;
    public Point Position => _position;
    public Size Size => _size;

    public abstract void Draw();
    public abstract void Update();

    protected void Log(string message)
    {
        LogService.Log(message);
    }
}