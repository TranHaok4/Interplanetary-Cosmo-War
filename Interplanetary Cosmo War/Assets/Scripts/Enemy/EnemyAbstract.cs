using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAbstract : HaoMonoBehaviour
{
    [Header("EnemyAbstract")]
    [SerializeField] protected EnemyCtrl enemyCtrl;

    public EnemyCtrl Enemy_Ctrl { get => enemyCtrl; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + ":LoadEnemyCtrl");
    }

}
