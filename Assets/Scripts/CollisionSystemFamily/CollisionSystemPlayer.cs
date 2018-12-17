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
            otherCol.PlayerCollision(this);
        }
    }

    public override void ArcRenderCollision(CollisionSystem cs)
    {
    }

    public override void DashObjectCollision(CollisionSystem cs)
    {
        print("collided with: dashobject");
    }

    public override void EnemyCollision(CollisionSystem cs)
    {
        GetComponent<RespawnInstance>().Respawn();
        print("collided with: enemy");
    }

    public override void PlayerCollision(CollisionSystem cs)
    {
    }

    public override void ProjectileCollision(CollisionSystem cs)
    {
        GetComponent<RespawnInstance>().Respawn();
        print("collided with: projectile");
    }

    public override void WallCollision(CollisionSystem cs)
    {
        print("collided with: wall");
    }
}
