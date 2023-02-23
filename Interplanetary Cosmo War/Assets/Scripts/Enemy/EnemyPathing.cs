using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : HaoMonoBehaviour
{
    [SerializeField] protected WaveConfigSO waveConfig;
    [SerializeField] protected List<Transform> waypoints;
    [SerializeField] protected EnemyCtrl enemyCtrl;
    protected int waypoint_Index = 0;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();

    }
    protected void LoadEnemyCtrl()
    {
        if (enemyCtrl != null) return;
        enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
    }
    protected void GetWayPoint()
    {
        waypoints = waveConfig.Get_WayPoints();
    }
    private void Update()
    {
        MovefollowPath();
    }
    public void Set_WaveConfig(WaveConfigSO waveconfig)
    {
        waypoint_Index = 0;
        this.waveConfig = waveconfig;
        this.GetWayPoint();
        transform.position = waypoints[0].transform.position;
    }
    protected void MovefollowPath()
    {
        if(waypoint_Index<waypoints.Count)
        {
            var target_position = waypoints[waypoint_Index].transform.position;
            float movement_thisframe = waveConfig.Move_Speed * Time.deltaTime;
            transform.parent.position = Vector2.MoveTowards(transform.parent.position, target_position, movement_thisframe);
            if(transform.position==target_position)
            {
                waypoint_Index++;
                if(waypoint_Index>=waypoints.Count)
                {
                    this.enemyCtrl.Enemy_Despawn.DespawnObject();
                }
            }
        }
    }
}
