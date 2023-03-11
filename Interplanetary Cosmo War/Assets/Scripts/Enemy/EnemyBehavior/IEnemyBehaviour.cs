using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IEnemyBehaviour : HaoMonoBehaviour
{
    protected EnemyBehaviourCtrl enemyBehaviourCtrl;

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

    public abstract void InvokeBehavior();
}
