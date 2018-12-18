using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSystemNearDashObject : CollisionSystem
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var otherCol = collision.GetComponent<CollisionSystem>();
        if (otherCol != null)
        {
            otherCol.NearDashObjectEnter(this);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        var otherCol = collision.GetComponent<CollisionSystem>();
        if (otherCol != null)
        {
            otherCol.NearDashObjectExit(this);
        }
    }

    public override void PlayerExit(CollisionSystem cs)
    {
        base.PlayerExit(cs);
        baseDashMechanic.SetTrigger(false);
    }
}
