using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStraightMoveToPlayer : IEnemyBehaviour
{


    [SerializeField] protected float moveSpeed = 0.05f;
    [SerializeField] protected Vector3 target;
    [SerializeField] Vector3 direction;
    float angle;
    protected override void LoadComponents()
    {
        base.LoadComponents();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        target = FindObjectOfType<ShipCtrl>().transform.position;
        direction = (target - transform.position).normalized;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }

    public override void InvokeBehavior()
    {
        StraightMove();
    }

    protected void StraightMove()
    {
        enemyBehaviourCtrl.Enemy_Ctrl.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
        enemyBehaviourCtrl.Enemy_Ctrl.transform.position += direction * moveSpeed * Time.deltaTime;
        if (Vector3.Distance(enemyBehaviourCtrl.Enemy_Ctrl.transform.position, target) < 0.1f)
        {
            moveSpeed = 0f;
        }
    }

}
