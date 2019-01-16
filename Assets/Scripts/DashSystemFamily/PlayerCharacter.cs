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

    [SerializeField]
    private float powerMaxDistance = 5;
    [SerializeField]
    private float zeroPoint = 0;

    DashPointData dashData;

    BaseDashObject currentDashObject;

    public void onDashCollision(BaseDashObject dashObject)
    {
        currentDashObject = dashObject;
        dashData = currentDashObject.GetData();

        currentDashObject.OnPlayerContact();
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

        dashArrowWidget.OnContact(transform.position, dashData);

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
        FindForceValue();
        dashData.ChangeDirection(MouseDirection());
        dashArrowWidget.PointInDirection(transform.position, dashData);
    }

    private void FindForceValue()
    {
        var powerLevel = DistanceToMouse() - dashArrowWidget.PowerMinDist(zeroPoint);
        if (powerLevel >= powerMaxDistance)
        {
            dashData.Force = dashData.MaxForce;

        }
        if (powerLevel <= 0)
        {
            dashData.Force = dashData.MinForce;
        }
        var percentage = (powerLevel / powerMaxDistance);
        dashData.Force = dashData.MaxForce * percentage;
    }

    private Vector3 MouseDirection()
    {
        return EventManager.eventManagerInstance.MouseToWorldPos2D() - (Vector2)transform.position;
    }
    private float DistanceToMouse()//TODO:Regulate
    {
        return Vector3.Distance(EventManager.eventManagerInstance.MouseToWorldPos2D(), (Vector2)transform.position);
    }

    public override void Respawn(Vector3 position, Quaternion rotation)
    {
        base.Respawn(position, rotation);
        RespawnManager.respawnManagerInstance.RespawnAllExceptThis(GetComponent<RespawnInstance>());
        if (dashArrowWidget != null)
        {
            dashArrowWidget.ResetArcRender();
        }
            
    }
}
