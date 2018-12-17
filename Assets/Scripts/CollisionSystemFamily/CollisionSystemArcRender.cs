using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSystemArcRender : CollisionSystem
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var otherCol = collision.GetComponent<CollisionSystem>();
        if (otherCol != null)
        {
            otherCol.ArcRenderCollision(this);
        }
    }

    public override void ArcRenderCollision(CollisionSystem cs)
    {
    }

    public override void DashObjectCollision(CollisionSystem cs)
    {
    }

    public override void EnemyCollision(CollisionSystem cs)
    {
    }

    public override void PlayerCollision(CollisionSystem cs)
    {
    }

    public override void ProjectileCollision(CollisionSystem cs)
    {
    }

    public override void WallCollision(CollisionSystem cs)
    {
        GetComponent<RespawnInstance>().Respawn();
    }
}
