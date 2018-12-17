using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopProjectilesOnWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectile")
        {
            collision.GetComponent<RespawnInstance>().Respawn();
        }
    }
}
