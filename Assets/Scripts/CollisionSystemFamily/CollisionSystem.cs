//Contains all collision possibilities

using UnityEngine;

public abstract class CollisionSystem : MonoBehaviour
{
    public virtual void EnemyCollision(CollisionSystem cs){}
    public virtual void PlayerCollision(CollisionSystem cs){}
    public virtual void DashObjectCollision(CollisionSystem cs){}
    public virtual void ProjectileCollision(CollisionSystem cs){}
    public virtual void WallCollision(CollisionSystem cs){}
    public virtual void ArcRenderCollision(CollisionSystem cs){}
}
