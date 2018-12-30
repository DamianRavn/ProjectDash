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
    private void OnTriggerExit2D(Collider2D collision)
    {
        var otherCol = collision.GetComponent<CollisionSystem>();
        if (otherCol != null)
        {
            otherCol.DashObjectExit(this);
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

    public override void RespawnEnter(CollisionSystem cs)
    {
        base.RespawnEnter(cs);
        GetComponent<RespawnInstance>().Respawn();
    }
}
