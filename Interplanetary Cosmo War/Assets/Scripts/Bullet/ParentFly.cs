using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentFly : HaoMonoBehaviour
{
    [SerializeField] IBulletStrategyFly bulletflyStrategy;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletFlyStrategy();
    }
    protected void LoadBulletFlyStrategy()
    {
        if (bulletflyStrategy != null) return;

        bulletflyStrategy = GetComponentInChildren<IBulletStrategyFly>();
        Debug.Log(transform.name + ":LoadBulletFlyStrategy");
    }


    protected void Update()
    {
        bulletflyStrategy.Fly(transform.parent);
    }

}
