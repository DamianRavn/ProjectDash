using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopArcRenderOnWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ArcRender")
        {
            collision.gameObject.GetComponent<RespawnInstance>().Respawn();
        }
    }
}
