using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager UIManagerInstance = null;

    public enum Scenes
    {

    }


    void Awake()
    {
        //Check if instance already exists
        if (UIManagerInstance == null)
            //if not, set instance to this
            UIManagerInstance = this;

        //If instance already exists and it's not this:
        else if (UIManagerInstance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }


}
