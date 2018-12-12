using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : BaseDashMechanic
{
    [SerializeField]
    DirectionDashArrow dashArrow;
    DashArrowWidget dashArrowWidget;

    [SerializeField]
    Renderer render;

    DashPointData dashData;

    BaseDashObject currentDashObject;
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DashPoint")
        {
            onDashCollision(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DashPoint")
        {
            collision.gameObject.GetComponent<StandardDashObject>().PlayerLeaving();
        }
    }

    private void onDashCollision(GameObject collision)
    {
        currentDashObject = collision.GetComponent<BaseDashObject>();
        dashData = currentDashObject.GetData();
        
        Prepare();
        ResetForce();
        NullifyGravity();
    }

    public override void Respawn(Vector3 position, Quaternion rotation)
    {
        base.Respawn(position, rotation);
        RespawnManager.respawnManagerInstance.RespawnAllExceptThis(GetComponent<RespawnInstance>());
    }

    public void Prepare()
    {
        if (dashArrowWidget == null)
        {
            dashArrowWidget = dashArrow.InstantiateArrow(render, dashData);
        }
        else
        {
            dashArrowWidget.Visible();
        }

        dashArrowWidget.OnContact(transform.position, ref dashData);

        Subscribe();
    }

    private void DashDelegate()
    {
        DashFromObject(dashData);
    }

    public override void DashFromObject(DashPointData data)
    {
        base.DashFromObject(data);
        currentDashObject.ObjectDash(data.ReverseDirection());
    }

    private void Subscribe()
    {
        EventManager.OnClickMovement += PointTowardsMouse;
        EventManager.OnClicked += DashDelegate;
    }

    public override void Unsubscribe()
    {
        base.Unsubscribe();
        EventManager.OnClickMovement -= PointTowardsMouse;
        EventManager.OnClicked -= DashDelegate;
        dashArrowWidget.Invisible();
        CancelInvoke();
    }
    private void PointTowardsMouse()
    {
        dashData.ChangeDirection(MouseDirection());
        dashArrowWidget.PointInDirection(transform.position, ref dashData);
    }

    private Vector3 MouseDirection()
    {
        return (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
    }
}
