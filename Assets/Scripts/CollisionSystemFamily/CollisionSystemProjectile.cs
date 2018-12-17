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
            otherCol.ProjectileCollision(this);
        }
    }

    public override void DashObjectCollision(CollisionSystem cs)
    {
        GetComponent<RespawnInstance>().Respawn();
    }

    public override void EnemyCollision(CollisionSystem cs)
    {
        GetComponent<RespawnInstance>().Respawn();
    }

    public override void PlayerCollision(CollisionSystem cs)
    {
        GetComponent<RespawnInstance>().Respawn();
    }

    public override void ProjectileCollision(CollisionSystem cs)
    {
        GetComponent<RespawnInstance>().Respawn();
    }

    public override void WallCollision(CollisionSystem cs)
    {
        GetComponent<RespawnInstance>().Respawn();
    }
}
