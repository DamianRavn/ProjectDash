//Contains all collision possibilities

using UnityEngine;

public abstract class CollisionSystem : MonoBehaviour
{
    public abstract void EnemyCollision(CollisionSystem cs);
    public abstract void PlayerCollision(CollisionSystem cs);
    public abstract void DashObjectCollision(CollisionSystem cs);
    public abstract void ProjectileCollision(CollisionSystem cs);
    public abstract void WallCollision(CollisionSystem cs);
}
