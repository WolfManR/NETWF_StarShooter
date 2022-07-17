using System.Drawing;

namespace StarShooter.GameEngine;

public class RectangleCollider
{
    private Rectangle _collisionRectangle;

    public RectangleCollider(GameObject parent)
    {
        Parent = parent;
        _collisionRectangle = new Rectangle(Point.Empty, parent.Size);
    }

    public GameObject Parent { get; }

    public event Action<GameObject, RectangleCollider>? Intersected;

    public bool IsCollide(RectangleCollider other)
    {
        UpdatePosition();
        var isCollide = _collisionRectangle.IntersectsWith(other._collisionRectangle);
        if(isCollide) Intersected?.Invoke(Parent, other);
        return isCollide;
    }

    private void UpdatePosition()
    {
        _collisionRectangle.Location = Parent.Position;
    }
}