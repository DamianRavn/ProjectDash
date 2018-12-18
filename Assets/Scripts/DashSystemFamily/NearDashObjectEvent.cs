using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearDashObjectEvent : MonoBehaviour
{
    [SerializeField]
    BaseDashObject baseDashMechanic;
    PlayerCharacter player;

    //If within distance, subscribe to onclick event
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var col = collision.GetComponent<PlayerCharacter>();
        if (col != null)
        {
            
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            return;
        }

        if (player != null)
        {
            player = null;
            
        }
        else
        {
            
        }
    }
    
}
