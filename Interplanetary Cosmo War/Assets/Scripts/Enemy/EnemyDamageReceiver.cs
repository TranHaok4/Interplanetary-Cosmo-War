using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class EnemyDamageReceiver : DamageReceiver
{
    [Header("EnemyDamageReceiver")]
    [SerializeField] protected BoxCollider2D boxcollider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
    }

    protected virtual void LoadCollider()
    {
        if (boxcollider != null) return;
        boxcollider = this.GetComponent<BoxCollider2D>();
        boxcollider.isTrigger = true;
        Debug.Log(transform.name + ":LoadCollider");
    }
    protected override void Ondead()
    {
        //todo
    }
}
