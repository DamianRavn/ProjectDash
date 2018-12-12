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
        SetTrigger(true);
        NullifyGravity();
    }


    public void PlayerLeaving()
    {
        SetTrigger(false);
    }

    private void SetTrigger(bool istrigger)
    {
        GetComponent<Collider2D>().isTrigger = istrigger;
    }

    /// <summary>
    /// When the player collides with DashObject, the player gets data
    /// </summary>
    public override DashPointData GetData()
    {
        var dashData = new DashPointData(standardForce.force, Vector2.up, standardGravity.gravity);
        return dashData;
    }
}
