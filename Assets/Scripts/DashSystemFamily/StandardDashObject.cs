using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardDashObject : BaseDashObject
{
    [SerializeField]
    private Force standardForce;

    [SerializeField]
    private Gravity standardGravity;
    

    /// <summary>
    /// Used to dash from objects
    /// </summary>
    public override void ObjectDash(DashPointData data)
    {
        DashFromObject(data);
    }

    public override void Respawn(Vector3 position, Quaternion rotation)
    {
        base.Respawn(position, rotation);
        var tmp = nearDashObjectEvent.color;
        tmp.a = 0;
        nearDashObjectEvent.color = tmp;
        OnPlayerContact();
    }

    

    /// <summary>
    /// When the player collides with DashObject, the player gets data
    /// </summary>
    public override void GetData(DashPointData dashData)
    {
        dashData.MaxForce = standardForce.force;
        dashData.GravityScale = standardGravity.gravity;
    }
}
