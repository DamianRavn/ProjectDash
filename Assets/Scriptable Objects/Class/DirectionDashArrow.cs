using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DirectionDashArrow", menuName = "ScriptableObjects/DirectionDashArrow")]
public class DirectionDashArrow : ScriptableObject
{
    public DashArrowWidget arrow;
    
    public DashArrowWidget InstantiateArrow(Transform parent)
    {
        return Instantiate(arrow, parent);
    }
}
