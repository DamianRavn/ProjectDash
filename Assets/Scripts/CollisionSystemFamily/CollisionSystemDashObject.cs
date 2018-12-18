using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSystemDashObject : CollisionSystem
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var otherCol = collision.GetComponent<CollisionSystem>();
        if (otherCol != null)
        {
            otherCol.DashObjectEnter(this);
        }
    }

    public override void EnemyEnter(CollisionSystem cs)
    {
        GetComponent<RespawnInstance>().Respawn();
    }

    public override void ProjectileEnter(CollisionSystem cs)
    {
        GetComponent<RespawnInstance>().Respawn();
    }

    public override void WallEnter(CollisionSystem cs)
    {
        GetComponent<StandardDashObject>().SetTrigger(false);
    }
}
