using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerAndArcRender : MonoBehaviour
{
    public List<BaseDashMechanic> dashList;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var dashdata = new DashPointData(15, Vector2.up + Vector2.right, 1);
            dashdata.Force = 15;
            for (int i = 0; i < dashList.Count; i++)
            {
                dashList[i].transform.position = Vector3.zero;
                dashList[i].DashFromObject(dashdata);
            }
        }


        print(string.Format("playerPos: {0}, arcPos: {1}", dashList[0].transform.position, dashList[1].transform.position));
    }

}
