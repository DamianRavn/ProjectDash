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
            player = col;
            EventManager.OnClick += closeEnoughToDash;
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
            EventManager.OnClick -= closeEnoughToDash;
        }
        else
        {
            baseDashMechanic.SetTrigger(false);
        }
        
       
    }

    private void closeEnoughToDash()
    {
        player.onDashCollision(baseDashMechanic);
        player = null;
        EventManager.OnClick -= closeEnoughToDash;
    }
}
