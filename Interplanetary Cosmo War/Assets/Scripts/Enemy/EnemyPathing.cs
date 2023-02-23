using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : HaoMonoBehaviour
{
    [SerializeField] protected WaveConfigSO waveConfig;
    [SerializeField] protected List<Transform> waypoint;
    protected int waypoint_Index = 0;



    protected void GetWayPoint()
    {
        waypoint = waveConfig.Get_WayPoints();
    }
    private void Update()
    {
        MovefollowPath();
    }
    public void Set_WaveConfig(WaveConfigSO waveconfig)
    {
        this.waveConfig = waveconfig;
        this.GetWayPoint();
        transform.position = waypoint[waypoint_Index].transform.position;
    }
    protected void MovefollowPath()
    {
        if(waypoint_Index<waypoint.Count)
        {
            var target_position = waypoint[waypoint_Index].transform.position;
            float movement_thisframe = waveConfig.Move_Speed * Time.deltaTime;
            transform.parent.position = Vector2.MoveTowards(transform.parent.position, target_position, movement_thisframe);
            if(transform.position==target_position)
            {
                waypoint_Index++;
            }
        }
    }
}
