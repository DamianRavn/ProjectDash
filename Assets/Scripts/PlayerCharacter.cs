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

    public void onDashCollision(BaseDashObject dashObject)
    {
        currentDashObject = dashObject;
        dashData = currentDashObject.GetData();
        
        Prepare();
        ResetForce();
        NullifyGravity();
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
        return ExtensionMethods.MouseToWorldPos2D() - (Vector2)transform.position;
    }

    public override void Respawn(Vector3 position, Quaternion rotation)
    {
        base.Respawn(position, rotation);
        RespawnManager.respawnManagerInstance.RespawnAllExceptThis(GetComponent<RespawnInstance>());
        dashArrowWidget.ResetArcRender();
    }
}
