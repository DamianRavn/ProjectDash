using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class NearDashObjectRenderRange : MonoBehaviour
{
    public Transform player;
    public NearDashObjectRange rangeObject;
}

class NearDashRangeBehavior : ComponentSystem
{
    struct Components
    {
        public NearDashObjectRenderRange nearDash;
        public SpriteRenderer spriteRendere;
    }

    protected override void OnUpdate()
    {
        foreach (var e in GetEntities<Components>())
        {
            var dist = Vector3.Distance(e.nearDash.player.position, e.nearDash.transform.position);
            if (dist < e.nearDash.rangeObject.range)
            {
                var colortmp = e.spriteRendere.color;
                colortmp.a = ExtensionMethods.Remap(dist, 0, e.nearDash.rangeObject.range, 0.3f, 0);
                e.spriteRendere.color = colortmp;
            }
            else
            {
                var colortmp = e.spriteRendere.color;
                colortmp.a = 0;
                e.spriteRendere.color = colortmp;
            }
        }
    }
}
