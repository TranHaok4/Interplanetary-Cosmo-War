using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : HaoMonoBehaviour
{
    [SerializeField] protected EnemyDespawn enemyDespawn;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyDespawn();
    }

    protected virtual void LoadEnemyDespawn()
    {
        if (this.enemyDespawn != null) return;
        enemyDespawn = GetComponentInChildren<EnemyDespawn>();
        Debug.Log(transform.name + ":LoadEnemyDespawn");
    }
}
