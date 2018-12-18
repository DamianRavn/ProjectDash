using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSystemWall : CollisionSystem
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var otherCol = collision.GetComponent<CollisionSystem>();
        if (otherCol != null)
        {
            otherCol.WallEnter(this);
        }
    }
}
