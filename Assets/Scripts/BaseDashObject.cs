using UnityEngine;

public abstract class BaseDashObject : BaseDashMechanic
{
    /// <summary>
    /// Used to dash from objects
    /// </summary>
    public abstract void ObjectDash(DashPointData data);

    /// <summary>
    /// When the player collides with DashObject, the player gives this script
    /// </summary>
    /// <param name="player">given as 'this' from PlayerCharacter script</param>
    public abstract DashPointData GetData();
}
