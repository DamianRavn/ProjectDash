using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DirectionDashArrow", menuName = "ScriptableObjects/DirectionDashArrow")]
public class DirectionDashArrow : ScriptableObject
{
    public DashArrowWidget arrow;
    
    public DashArrowWidget InstantiateArrow(Renderer parent, DashPointData data)
    {
        DashArrowWidget aw = Instantiate(arrow, parent.transform);
        aw.OnInstantiate(parent, data);
        return aw;
    }
}
