using StarShooter.GameEngine;
using StarShooter.Prefabs;

namespace StarShooter;

public interface IHealth : IGameObject
{
    bool IsDestroyed { get; }
    int BaseHealth { get; }
    int Health { get; set; }
    int Damage { get; }
    void Damaged(object other, int value);
}

public interface IGameObject
{
    RectangleCollider Collider { get; }
}

public interface IBonus : IGameObject
{
    void Bonus(IHealth health);
}