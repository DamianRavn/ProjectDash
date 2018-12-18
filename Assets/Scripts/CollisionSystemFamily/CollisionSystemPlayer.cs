using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSystemPlayer : CollisionSystem
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var otherCol = collision.GetComponent<CollisionSystem>();
        if (otherCol != null)
        {
            otherCol.PlayerEnter(this);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        var otherCol = collision.GetComponent<CollisionSystem>();
        if (otherCol != null)
        {
            otherCol.PlayerExit(this);
        }
    }

    public override void EnemyEnter(CollisionSystem cs)
    {
        base.EnemyEnter(cs);
        GetComponent<RespawnInstance>().Respawn();
    }

    public override void ProjectileEnter(CollisionSystem cs)
    {
        base.ProjectileEnter(cs);
        GetComponent<RespawnInstance>().Respawn();
        print("collided with: projectile");
    }

    public override void NearDashObjectEnter(CollisionSystem cs)
    {
        base.NearDashObjectEnter(cs);
        EventManager.OnClick += closeEnoughToDash;
    }
    public override void NearDashObjectExit(CollisionSystem cs)
    {
        base.NearDashObjectExit(cs);
        EventManager.OnClick -= closeEnoughToDash;
    }



    private void closeEnoughToDash()
    {
        GetComponent<PlayerCharacter>().onDashCollision(baseDashMechanic);
        EventManager.OnClick -= closeEnoughToDash;
    }
}
