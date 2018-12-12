using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempRespawn : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var hmm = collision.gameObject.GetComponent<RespawnInstance>();
        if (hmm != null)
        {
            hmm.Respawn();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var hmm = collision.gameObject.GetComponent<RespawnInstance>();
        if (hmm != null)
        {
            hmm.Respawn();
        }
    }

}
