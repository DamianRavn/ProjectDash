using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashArrowWidget : MonoBehaviour
{
    [SerializeField]
    private Renderer thisRendere;

    [SerializeField]
    private Renderer arrowFillRendere;

    [SerializeField]
    TrajectoryArcRender arcRenderPrefab;
    TrajectoryArcRender arcRender;
    private Vector2 arcRenderStartPos;
    

    private float minDistance;

    private float smoothTime = 0.01F;
    private Vector3 velocity = Vector3.zero;

    private EventManager.ClickAction renderArcEvent;
    private EventManager.ClickAction subscribeArcEvent;
    private DashPointData dashData;


    public void OnContact(Vector2 center, DashPointData dashData)
    {
        this.dashData = dashData;
        arcRenderStartPos = center;
        PointInDirection(center, dashData);
    }

    public void OnInstantiate(Renderer parent, DashPointData dashData)
    {
        this.dashData = dashData;
        minDistance = FindMinDist(parent);
        arcRenderStartPos = parent.transform.position;
        

        arcRender = arcRenderPrefab.OnInstantiate(arcRenderStartPos, transform);

        //These two events keep each other up to date
        renderArcEvent = delegate 
        {
            StartCoroutine(ArcRender(this.dashData));
            EventManager.OnClickMovement += subscribeArcEvent;
            EventManager.OnClickMouseUnmoving -= renderArcEvent;
        };
        subscribeArcEvent = delegate
        {
            EventManager.OnClickMouseUnmoving += renderArcEvent;
            EventManager.OnClickMovement -= subscribeArcEvent;
        };
        EventManager.OnClickMouseUnmoving += renderArcEvent;
    }

    public float PowerMinDist(float zeroPoint)
    {
        //Half of the biggest side to get the tip of the arrow, then a number to how far away from the tip is the 0 point
        return FindRenderTipDistance() + zeroPoint;
    }

    private float FindRenderTipDistance()
    {
        return ((thisRendere.bounds.size.x > thisRendere.bounds.size.y ? thisRendere.bounds.size.x : thisRendere.bounds.size.y) / 2);
    }

    private float FindMinDist(Renderer parent)
    {
        //Find the point where the bounds are biggest and use the added product
        return (thisRendere.bounds.size.x > thisRendere.bounds.size.y ? thisRendere.bounds.size.x : thisRendere.bounds.size.y)/2 + (parent.bounds.size.x > parent.bounds.size.y ? parent.bounds.size.x : parent.bounds.size.y)/2;
    }

    public void PointInDirection(Vector2 center, DashPointData dashData)
    {
        RotateTowards(dashData.NormalizedDirection);
        MoveToPosition(center, dashData.NormalizedDirection);
        SetDissolveValue(FindDesolveValue(dashData));
        arcRender.Reset();
    }

    private void RotateTowards(Vector3 normalizedDir)
    {
        float rot_z = Mathf.Atan2(normalizedDir.y, normalizedDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }

    private void MoveToPosition(Vector2 center, Vector2 dir)
    {
        //The position of the arrow is the minimum distance away in the direction of the mouse
        Vector2 targetPos = center + (dir * minDistance);
        //Adds a slight delay giving the arrow a bit more personality
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }

    private float FindDesolveValue(DashPointData dashData)
    {
        return dashData.Force.Remap(dashData.MinForce, dashData.MaxForce, 1, 0.01f);
    }

    public void SetDissolveValue(float value)
    {
        var newValue = Mathf.Clamp(value, 0.01f, 1);
        arrowFillRendere.material.SetFloat("_DissolveValue", newValue);
    }
    

    private IEnumerator ArcRender(DashPointData dashData)
    {
        arcRender.ResetPos(arcRenderStartPos);
        yield return new WaitForEndOfFrame();
        arcRender.RenderArc(dashData);
        
    }

    public void Visible()
    {
        SetVisibility(true);
        EventManager.OnClickMouseUnmoving += renderArcEvent;
    }
    public void Invisible()
    {
        SetVisibility(false);
        EventManager.OnClickMouseUnmoving -= renderArcEvent;
        EventManager.OnClickMovement -= subscribeArcEvent;
    }

    private void SetVisibility(bool visible)
    {
        thisRendere.enabled = visible;
        arrowFillRendere.enabled = visible;
    }

    public void ResetArcRender()
    {
        if (arcRender != null)
        {
            arcRender.Reset();
        }
    }
}
