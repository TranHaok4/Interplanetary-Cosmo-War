using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class EnemyDamageReceiver : DamageReceiver
{
    [Header("EnemyDamageReceiver")]
    [SerializeField] protected BoxCollider2D boxcollider;

    [SerializeField] protected EnemyCtrl enemyCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadEnemyCtrl();
    }

    protected virtual void LoadCollider()
    {
        if (boxcollider != null) return;
        boxcollider = this.GetComponent<BoxCollider2D>();
        boxcollider.isTrigger = true;
        Debug.Log(transform.name + ":LoadCollider");
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + ":LoadEnemyCtrl");
    }
    protected override void Ondead()
    {

    }
    public override void Add(int value)
    {
        enemyCtrl.Enemy_Health.Add(value);
    }
    public override void Deduct(int value)
    {
        enemyCtrl.Enemy_Shield.Deduct(value);
        if(!checkIsShieldEnble())
        {
            enemyCtrl.Enemy_Health.Deduct(value);
        }
    }

    protected bool checkIsShieldEnble()
    {
        return enemyCtrl.Enemy_Shield.Is_ShieldActive;
    }
}
