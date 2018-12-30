using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSystemProjectile : CollisionSystem
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var otherCol = collision.GetComponent<CollisionSystem>();
        if (otherCol != null)
        {
            otherCol.ProjectileEnter(this);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        var otherCol = collision.GetComponent<CollisionSystem>();
        if (otherCol != null)
        {
            otherCol.ProjectileExit(this);
        }
    }

    public override void DashObjectEnter(CollisionSystem cs)
    {
        GetComponent<RespawnInstance>().Respawn();
    }

    public override void EnemyEnter(CollisionSystem cs)
    {
        GetComponent<RespawnInstance>().Respawn();
    }

    public override void PlayerEnter(CollisionSystem cs)
    {
        GetComponent<RespawnInstance>().Respawn();
    }

    public override void ProjectileEnter(CollisionSystem cs)
    {
        GetComponent<RespawnInstance>().Respawn();
    }

    public override void WallEnter(CollisionSystem cs)
    {
        GetComponent<RespawnInstance>().Respawn();
    }
}
