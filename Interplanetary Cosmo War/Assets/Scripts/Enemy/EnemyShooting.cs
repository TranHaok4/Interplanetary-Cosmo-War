using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : HaoMonoBehaviour
{
    [SerializeField] protected EnemyBulletEnum bulletEnemyName;

    [SerializeField] protected float shootDelay;
    [SerializeField] protected float shootTimer;

    [SerializeField] protected GunPosition gunPos;

    [SerializeField] protected ShootingStrategy _shootingStrategy;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGunPos();
        this.LoadShootingStrategy();
    }
    protected virtual void LoadGunPos()
    {
        if (gunPos != null)
        {
            return;
        }
        gunPos = this.GetComponentInChildren<GunPosition>();
        Debug.Log(transform.name + ":LoadGunPos");
    }
    protected virtual void LoadShootingStrategy()
    {
        if (_shootingStrategy != null)
        {
            return;
        }
        _shootingStrategy = this.GetComponentInChildren<ShootingStrategy>();
        Debug.Log(transform.name + ":LoadShootingStrategy");
    }


    private void FixedUpdate()
    {
        this.Shooting();
    }

    protected virtual void Shooting()
    {
        shootTimer += Time.fixedDeltaTime;
        if (shootTimer < shootDelay) return;
        shootTimer = 0f;
        _shootingStrategy.Shoot(bulletEnemyName.ToString(), gunPos, this.transform.parent);

    }
}
