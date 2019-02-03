using UnityEngine;

public abstract class BaseDashObject : BaseDashMechanic
{
    [SerializeField]
    protected SpriteRenderer nearDashObjectEvent;

    /// <summary>
    /// Used to dash from objects
    /// </summary>
    public abstract void ObjectDash(DashPointData data);

    /// <summary>
    /// When the player collides with DashObject, the player gives this script
    /// </summary>
    /// <param name="player">given as 'this' from PlayerCharacter script</param>
    public abstract void GetData(DashPointData dashData);

    public virtual void OnPlayerContact()
    {
        SetTrigger(true);
        NullifyGravity();
        ResetForce();
    }
}
