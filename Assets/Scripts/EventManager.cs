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
    public float timeBeforeEvent = 0.3f;
    
    private Camera cam;

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
        cam = Camera.main;
    }
    public Vector2 MouseToWorldPos2D()
    {
        return cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Update()
    {
        if (UIBase.gameIsPaused)
        {
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            OnClick?.Invoke();
        }

        if (Input.GetButton("Fire1"))
        {
            if (!breathingRoom.Contains(Input.mousePosition))
            {
                //print(string.Format("boundsPos: {0}, mousePos: {1}", breathingRoom.center, Input.mousePosition));
                OnClickMovement?.Invoke();
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


        if (Input.GetButtonUp("Fire1"))
        {
            CancelInvoke();
            OnClicked?.Invoke();
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
        OnClickMouseUnmoving?.Invoke();
    }

}
