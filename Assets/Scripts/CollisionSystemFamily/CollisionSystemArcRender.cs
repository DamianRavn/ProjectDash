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
            otherCol.ArcRenderEnter(this);
        }
    }

    public override void WallEnter(CollisionSystem cs)
    {
        GetComponent<RespawnInstance>().Respawn();
    }
}
