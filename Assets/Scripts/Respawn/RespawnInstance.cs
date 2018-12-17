using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnInstance : MonoBehaviour
{
    Vector3 respawnPos;
    Quaternion respawnRot;


    private void Start()
    {
        respawnPos = transform.position;
        respawnRot = transform.rotation;
        GiveSelf();
    }

    private void GiveSelf()
    {
        RespawnManager.respawnManagerInstance.RecordInstance(this);
    }

    public void Respawn()
    {
        GetComponent<BaseDashMechanic>().Respawn(respawnPos, respawnRot);
    }

}
