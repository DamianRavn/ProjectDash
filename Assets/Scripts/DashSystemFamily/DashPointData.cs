using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPointData
{
    /// <summary>
    /// An object for direction and force
    /// </summary>
    /// <param name="maxForce"></param>
    /// <param name="direction">Normalized in creation</param>


    public DashPointData(float maxForce, Vector2 direction, float gravityScale)
    {
        MaxForce = maxForce;
        MinForce = 5f;
        this.GravityScale = gravityScale;
        ChangeDirection(direction);
    }

    public DashPointData()
    {

    }

    public float Force
    {
        get;
        set;
    }

    public float MaxForce
    {
        get;
        set;
    }

    public Vector2 NormalizedDirection
    {
        get;

        private set;
    }

    public float GravityScale
    {
        get;

        set;
    }

    public float MinForce
    {
        get;

        private set;
    }

    public void ChangeDirection(Vector2 direction)
    {
        NormalizedDirection = direction.normalized;
    }

    public DashPointData ReverseDirection()
    {
        NormalizedDirection = -NormalizedDirection;
        return this;
    }
}
