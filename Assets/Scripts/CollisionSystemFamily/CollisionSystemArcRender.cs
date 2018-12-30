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
    private void OnTriggerExit2D(Collider2D collision)
    {
        var otherCol = collision.GetComponent<CollisionSystem>();
        if (otherCol != null)
        {
            otherCol.ArcRenderExit(this);
        }
    }

    public override void WallEnter(CollisionSystem cs)
    {
        base.WallEnter(cs);
        GetComponent<RespawnInstance>().Respawn();
    }

    public override void RespawnEnter(CollisionSystem cs)
    {
        base.RespawnEnter(cs);
        GetComponent<RespawnInstance>().Respawn();
    }
}
