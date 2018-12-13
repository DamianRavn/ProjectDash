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
    public static event ClickAction OnClickMouseUnmoving;

    //OnClickMouseUnmoving variables
    private float timeBeforeEvent = 1;

    //onclickmovement variables
    private Bounds breathingRoom;

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

    private void Start()
    {
        OnClick += CreateBoundsForMousePos;
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
            if (!breathingRoom.Contains(Input.mousePosition))
            {
                //print(string.Format("boundsPos: {0}, mousePos: {1}", breathingRoom.center, Input.mousePosition));
                if (OnClickMovement != null)
                {
                    OnClickMovement();
                }
                breathingRoom.center = Input.mousePosition;
                CancelInvoke("UnmovingMouse");
            }
            else
            {
                if (!IsInvoking("UnmovingMouse"))
                {
                    Invoke("UnmovingMouse", timeBeforeEvent);
                }
                
            }
        }


        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            CancelInvoke();
            if(OnClicked != null)
                OnClicked();
        }
    }

    private void CreateBoundsForMousePos()
    {
        var boundsSize = new Vector3(18, 18, 0);
        breathingRoom = new Bounds(Input.mousePosition, boundsSize);
        OnClick -= CreateBoundsForMousePos; //This is only needed on first click
        
    }

    private void UnmovingMouse()
    {
        if (OnClickMouseUnmoving != null)
        {
            OnClickMouseUnmoving();
        }
        
    }

}
