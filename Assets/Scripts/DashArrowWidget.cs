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
    private float arrowTipDis;

    public float powerMaxDistance = 5;
    private float powerMinDistance;
    public float zeroPoint = 0;

    private float minDistance;

    private float smoothTime = 0.01F;
    private Vector3 velocity = Vector3.zero;

    private bool isRenderingArc = false;

    public void OnContact(Vector2 parent, ref DashPointData data)
    {
        Vector2 center = parent;

        PointInDirection(center, ref data);
    }

    public void OnInstantiate(Renderer parent, DashPointData data)
    {
        minDistance = FindMinDist(parent);
        arrowTipDis = FindRenderTipDistance();
        //Half of the biggest side to get the tip of the arrow, then a number to how far away from the tip is the 0 point
        powerMinDistance = FindRenderTipDistance() + zeroPoint;

        arcRender = arcRenderPrefab.OnInstantiate(FindArcRenderStartPos(data), data, transform);
    }


    private float FindRenderTipDistance()
    {
        return ((thisRendere.bounds.size.x > thisRendere.bounds.size.y ? thisRendere.bounds.size.x : thisRendere.bounds.size.y) / 2);
    }
    private Vector3 FindArcRenderStartPos(DashPointData data)
    {
        return (Vector2)transform.position + (data.NormalizedDirection * arrowTipDis);
    }

    private float FindMinDist(Renderer parent)
    {
        //Find the point where the bounds are biggest and use the added product
        return (thisRendere.bounds.size.x > thisRendere.bounds.size.y ? thisRendere.bounds.size.x : thisRendere.bounds.size.y)/2 + (parent.bounds.size.x > parent.bounds.size.y ? parent.bounds.size.x : parent.bounds.size.y)/2;
    }

    public void PointInDirection(Vector2 center, ref DashPointData data)
    {
        RotateTowards(data.NormalizedDirection);
        MoveToPosition(center, data.NormalizedDirection);
        SetDissolveValue(FindDissolveValue(ref data));
        StartArcRender(data);
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

    /// <summary>
    /// Uses the max and min powerdistance, and distance to mouse to take percentage of Force and find how big the arrow fill should be
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    private float FindDissolveValue(ref DashPointData data)
    {
        var powerLevel = DistanceToMouse() - powerMinDistance;
        if (powerLevel >= powerMaxDistance)
        {
            data.Force = data.MaxForce;
            return 0.01f;
            
        }
        if (powerLevel <= 0)
        {
            data.Force = data.MinForce;
            return 1f;
        }
        var percentage = (powerLevel / powerMaxDistance);
        data.Force = data.MaxForce * percentage;
        return data.Force.Remap(data.MinForce, data.MaxForce, 1, 0.01f);
    }
    private float DistanceToMouse()
    {
        return Vector3.Distance((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), (Vector2)transform.position);
    }

    private void SetDissolveValue(float value)
    {
        var newValue = Mathf.Clamp(value, 0.01f, 1);
        arrowFillRendere.material.SetFloat("_DissolveValue", newValue);
    }

    private void StartArcRender(DashPointData data)
    {
        if (isRenderingArc)
        {
            StopCoroutine("ArcRender");
            isRenderingArc = false;
            arcRender.Reset();
        }
        else
        {
            StartCoroutine(ArcRender(data));
        }
        
    }

    private IEnumerator ArcRender(DashPointData data)
    {
        isRenderingArc = true;
        yield return new WaitForSeconds(1);
        arcRender.ResetPos(FindArcRenderStartPos(data));
        yield return new WaitForEndOfFrame();
        arcRender.RenderArc(data);
        isRenderingArc = false;
    }

    public void Visible()
    {
        SetVisibility(true);
        arcRender.Reset();
    }
    public void Invisible()
    {
        SetVisibility(false);
        arcRender.Reset();
    }

    private void SetVisibility(bool visible)
    {
        thisRendere.enabled = visible;
        arrowFillRendere.enabled = visible;
    }
}
