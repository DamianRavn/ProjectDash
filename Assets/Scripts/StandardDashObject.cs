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
        OnPlayerContact();
    }

    

    /// <summary>
    /// When the player collides with DashObject, the player gets data
    /// </summary>
    public override DashPointData GetData()
    {
        var dashData = new DashPointData(standardForce.force, Vector2.up + Vector2.right, standardGravity.gravity);
        return dashData;
    }
}
