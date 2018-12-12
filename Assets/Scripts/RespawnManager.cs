using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public static RespawnManager respawnManagerInstance = null;

    private List<RespawnInstance> recordedInstances;

    void Awake()
    {
        //Check if instance already exists
        if (respawnManagerInstance == null)
            //if not, set instance to this
            respawnManagerInstance = this;

        //If instance already exists and it's not this:
        else if (respawnManagerInstance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        recordedInstances = new List<RespawnInstance>();
    }

    public void RecordInstance(RespawnInstance instance)
    {
        recordedInstances.Add(instance);
    }

    public void RespawnAllExceptThis(RespawnInstance instance)
    {
        for (int i = 0; i < recordedInstances.Count; i++)
        {
            if(recordedInstances[i] != instance)
            {
                recordedInstances[i].Respawn();
                //var s = String.Format("RecordedInstance: {0}, i: {1}, length: {2}", recordedInstances[i], i, recordedInstances.Count);
                //print(s);
            }
                
        }
    }

    public void RespawnAll()
    {
        for (int i = 0; i < recordedInstances.Count; i++)
        {
            recordedInstances[i].Respawn();
        }
    }
}
