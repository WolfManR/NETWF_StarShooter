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

    public bool IsCollide(RectangleCollider other)
    {
        UpdateCollisionPosition();
        other.UpdateCollisionPosition();
        return _collisionRectangle.IntersectsWith(other._collisionRectangle);
    }

    private void UpdateCollisionPosition()
    {
        _collisionRectangle.Location = Parent.Position;
    }
}