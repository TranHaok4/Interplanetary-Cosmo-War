using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathingBehaviour : IEnemyBehaviour
{
    [SerializeField] protected EnemyBehaviourCtrl enemyBehaviourCtrl;

    [SerializeField] protected WaveConfigSO waveConfig;
    [SerializeField] protected List<Transform> waypoints;
    protected int waypoint_Index = 0;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyBehaviourCtrl();

    }
    protected void LoadEnemyBehaviourCtrl()
    {
        if (enemyBehaviourCtrl != null) return;
        enemyBehaviourCtrl = transform.parent.GetComponent<EnemyBehaviourCtrl>();
    }
    protected void GetWayPoint()
    {
        waypoints = waveConfig.Get_WayPoints();
    }
    public override void InvokeBehavior()
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
        if(waveConfig==null)
        {
            Debug.LogWarning("enemy nay chi duoc spawn tu stage ahahha");
            return;
        }
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
                    this.enemyBehaviourCtrl.Enemy_Ctrl.Enemy_Despawn.DespawnObject();
                }
            }
        }
    }
}
