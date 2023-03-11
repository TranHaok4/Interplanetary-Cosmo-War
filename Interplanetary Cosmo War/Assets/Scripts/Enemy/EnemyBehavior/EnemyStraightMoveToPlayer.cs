using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStraightMoveToPlayer : IEnemyBehaviour
{
    [SerializeField] protected EnemyBehaviourCtrl enemyBehaviourCtrl;


    [SerializeField] protected float moveSpeed = 0.05f;
    [SerializeField] protected Transform target;
    [SerializeField] Vector3 direction;
    float angle;
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
    protected override void OnEnable()
    {
        base.OnEnable();
        target = FindObjectOfType<ShipCtrl>().transform;
        direction = (target.position - transform.position).normalized;
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
    }

}
