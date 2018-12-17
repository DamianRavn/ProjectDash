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
            otherCol.DashObjectCollision(this);
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
        GetComponent<RespawnInstance>().Respawn();
    }

    public override void PlayerCollision(CollisionSystem cs)
    {
        print("collided with: player");
    }

    public override void ProjectileCollision(CollisionSystem cs)
    {
        GetComponent<RespawnInstance>().Respawn();
    }

    public override void WallCollision(CollisionSystem cs)
    {
        GetComponent<StandardDashObject>().SetTrigger(false);
    }
}
