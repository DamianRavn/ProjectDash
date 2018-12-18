using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSystemEnemy : CollisionSystem
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var otherCol = collision.GetComponent<CollisionSystem>();
        if (otherCol != null)
        {
            otherCol.EnemyEnter(this);
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

    public override void ProjectileEnter(CollisionSystem cs)
    {
        GetComponent<RespawnInstance>().Respawn();
    }
}
