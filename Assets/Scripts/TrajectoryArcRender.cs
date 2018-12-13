using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryArcRender : BaseDashMechanic
{
    [SerializeField]
    TrailRenderer trailRenderer;

    public TrajectoryArcRender OnInstantiate(Vector3 pos, Transform parent)
    {
        var ar = Instantiate(this, parent);
        ar.ResetPos(pos);
        ar.SetTrigger(false);
        return ar;
    }

    public void RenderArc(DashPointData data)
    {
        StartRender();
        DashFromObject(data);
    }

    private void StartRender()
    {
        renderingArc(true);
        SetTrigger(false);
    }

    private void StopRender()
    {
        renderingArc(false);
        SetTrigger(true);
        trailRenderer.Clear();
        
    }

    private void renderingArc(bool render)
    {
        trailRenderer.emitting = render;
    }

    public void ResetPos(Vector3 pos)
    {
        transform.position = pos;
        Reset();
    }
    public void Reset()
    {
        StopRender();
        ResetForce();
        NullifyGravity();
    }

    public override void Respawn(Vector3 position, Quaternion rotation)
    {
        ResetForce();
        NullifyGravity();
    }
}
