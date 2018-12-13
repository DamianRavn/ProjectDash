using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDashMechanic : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D thisRigidbody;

    public Rigidbody2D ThisRigidbody
    {
        get
        {
            return thisRigidbody;
        }
        set
        {
            thisRigidbody = value;
        }
    }
    

    public virtual void DashFromObject(DashPointData data)
    {
        SetGravity(data.GravityScale);
        Dash(data.Force, data.NormalizedDirection, ForceMode2D.Impulse);
        Unsubscribe();
    }

    /// <summary>
    /// Adds force to the rigidbody
    /// </summary>
    /// <param name="force"></param>
    /// <param name="direction"></param>
    /// <param name="forceMode"></param>
    private void Dash(float force, Vector2 direction, ForceMode2D forceMode)
    {
        ThisRigidbody.AddForce(direction * force, forceMode);
    }

    /// <summary>
    /// Sets velocity to 0
    /// </summary>
    public void ResetForce()
    {
        ThisRigidbody.velocity = Vector2.zero;
        ThisRigidbody.angularVelocity = 0;
    }

    /// <summary>
    /// Set Rigidbody gravityScale to 0
    /// </summary>
    public void NullifyGravity()
    {
        SetGravity(0);
    }

    /// <summary>
    /// Set Gravity Scale of Rigidbody
    /// </summary>
    /// <param name="gravity"></param>
    public void SetGravity(float gravity)
    {
        ThisRigidbody.gravityScale = gravity;
    }

    public void SetTrigger(bool istrigger)
    {
        GetComponent<Collider2D>().isTrigger = istrigger;
    }

    public virtual void Unsubscribe()
    {

    }


    /// <summary>
    /// Respawn mechanics specific to individual
    /// </summary>
    public virtual void Respawn(Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        transform.rotation = rotation;
        ResetForce();
    }
}
