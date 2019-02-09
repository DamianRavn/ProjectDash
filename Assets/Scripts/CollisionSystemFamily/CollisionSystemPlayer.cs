using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSystemPlayer : CollisionSystem
{
    private EventManager.ClickAction fuckingWorkAround;
    private bool fuckingSecurityAgainstAddingTwoEvents = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var otherCol = collision.GetComponent<CollisionSystem>();
        if (otherCol != null)
        {
            otherCol.PlayerEnter(this);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        var otherCol = collision.GetComponent<CollisionSystem>();
        if (otherCol != null)
        {
            otherCol.PlayerExit(this);
        }
    }

    public override void EnemyEnter(CollisionSystem cs)
    {
        base.EnemyEnter(cs);
        GetComponent<RespawnInstance>().Respawn();
    }

    public override void ProjectileEnter(CollisionSystem cs)
    {
        base.ProjectileEnter(cs);
        GetComponent<RespawnInstance>().Respawn();
    }

    public override void RespawnEnter(CollisionSystem cs)
    {
        base.RespawnEnter(cs);
        GetComponent<RespawnInstance>().Respawn();
    }

    public override void NearDashObjectEnter(CollisionSystem cs)
    {
        base.NearDashObjectEnter(cs);
        if (fuckingSecurityAgainstAddingTwoEvents )
        {
            return;
        }
        fuckingSecurityAgainstAddingTwoEvents = true;
        var nearDash = cs as CollisionSystemNearDashObject;
        fuckingWorkAround = delegate
        {
            closeEnoughToDash(nearDash.baseDashObject); 
        };
        EventManager.OnClick += fuckingWorkAround;
    }
    public override void NearDashObjectExit(CollisionSystem cs)
    {
        base.NearDashObjectExit(cs);
        fuckingSecurityAgainstAddingTwoEvents = false;
        EventManager.OnClick -= fuckingWorkAround;
    }
    
    private void closeEnoughToDash(BaseDashObject baseDashObject)
    {
        GetComponent<PlayerCharacter>().onDashCollision(baseDashObject);
        fuckingSecurityAgainstAddingTwoEvents = false;
        print("Dashing! " + baseDashObject);
        EventManager.OnClick -= fuckingWorkAround;
    }


}
