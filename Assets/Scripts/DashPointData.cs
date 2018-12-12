using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPointData
{
    /// <summary>
    /// An object that only holds data
    /// </summary>
    /// <param name="force"></param>
    /// <param name="direction">Normalized in creation</param>
    public DashPointData(float force, Vector2 direction, float gravityScale)
    {
        MaxForce = force;
        MinForce = 0.1f;
        this.GravityScale = gravityScale;
        ChangeDirection(direction);
    }

    private float maxForce;
    private float minForce;
    private float force;
    private Vector2 normalizedDirection;
    private float gravityScale;

    public float Force
    {
        get
        {
            return force;
        }

        set
        {
            force = value;
        }
    }

    public float MaxForce
    {
        get
        {
            return maxForce;
        }

        private set
        {
            maxForce = value;
        }
    }

    public Vector2 NormalizedDirection
    {
        get
        {
            return normalizedDirection;
        }

        private set
        {
            normalizedDirection = value;
        }
    }

    public float GravityScale
    {
        get
        {
            return gravityScale;
        }

        set
        {
            gravityScale = value;
        }
    }

    public float MinForce
    {
        get
        {
            return minForce;
        }

        private set
        {
            minForce = value;
        }
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
