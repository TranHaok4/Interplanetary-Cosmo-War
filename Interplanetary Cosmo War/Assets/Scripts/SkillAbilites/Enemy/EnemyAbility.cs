using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAbility : HaoMonoBehaviour
{
    [SerializeField] protected int cooldown;
    [SerializeField] protected EnemyAbilityCtrl enemyAbilityCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyAbilityCtrl();
    }

    protected void LoadEnemyAbilityCtrl()
    {
        if (enemyAbilityCtrl != null) return;
        enemyAbilityCtrl = transform.parent.GetComponent<EnemyAbilityCtrl>();
        Debug.Log(transform.name + "LoadEnemyAbilityCtrl");
    }

    public abstract void InvokeAbility();
}
