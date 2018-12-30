using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSystemRespawn : CollisionSystem
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var otherCol = collision.GetComponent<CollisionSystem>();
        if (otherCol != null)
        {
            otherCol.RespawnEnter(this);
        }
    }
    /*private void OnTriggerExit2D(Collider2D collision)
    {
        var otherCol = collision.GetComponent<CollisionSystem>();
        if (otherCol != null)
        {
            otherCol.RespawnExit(this);
        }
    }*/


}
