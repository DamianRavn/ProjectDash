//Contains all collision possibilities

using UnityEngine;

public abstract class CollisionSystem : MonoBehaviour
{
    //OnTriggerEnter
    public virtual void EnemyEnter(CollisionSystem cs){}
    public virtual void PlayerEnter(CollisionSystem cs){}
    public virtual void DashObjectEnter(CollisionSystem cs){}
    public virtual void ProjectileEnter(CollisionSystem cs){}
    public virtual void WallEnter(CollisionSystem cs){}
    public virtual void ArcRenderEnter(CollisionSystem cs){}
    public virtual void NearDashObjectEnter(CollisionSystem cs) { }

    //OnTriggerExit
    public virtual void EnemyExit(CollisionSystem cs) { }
    public virtual void PlayerExit(CollisionSystem cs) { }
    public virtual void DashObjectExit(CollisionSystem cs) { }
    public virtual void ProjectileExit(CollisionSystem cs) { }
    public virtual void WallExit(CollisionSystem cs) { }
    public virtual void ArcRenderExit(CollisionSystem cs) { }
    public virtual void NearDashObjectExit(CollisionSystem cs) { }
}
