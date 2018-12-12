using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager eventManagerInstance = null;

    public delegate void ClickAction();
    public static event ClickAction OnClicked;
    public static event ClickAction OnClick;
    public static event ClickAction OnClickMovement;

    //onclickmovement variables
    private Bounds breathingRoom;
    public Vector3 boundsSize;

    void Awake()
    {
        //Check if instance already exists
        if (eventManagerInstance == null)
            //if not, set instance to this
            eventManagerInstance = this;

        //If instance already exists and it's not this:
        else if (eventManagerInstance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (OnClick != null)
            {
                OnClick();
            }
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            CheckIfBoundsExists();
            if (!breathingRoom.Contains(ExtensionMethods.MouseToWorldPos2D()))
            {
                print(string.Format("boundsPos: {0}, mousePos: {1}", breathingRoom.center, ExtensionMethods.MouseToWorldPos2D()));
                if (OnClickMovement != null)
                {
                    OnClickMovement();
                }
                breathingRoom.center = ExtensionMethods.MouseToWorldPos2D();
            }
        }


        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            CancelInvoke();
            if(OnClicked != null)
                OnClicked();
        }
    }

    private void CheckIfBoundsExists()
    {
        if (breathingRoom == null)
        {
            breathingRoom = new Bounds(ExtensionMethods.MouseToWorldPos2D(), boundsSize);
        }
    }

}
