using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : HaoMonoBehaviour
{
    [SerializeField] protected EnemyBulletEnum enemyName;

    [SerializeField] protected float shootDelay;
    [SerializeField] protected float shootTimer;

    [SerializeField] protected GunPosition gunPos;

    [SerializeField] protected ShootingType shootingType;
    [SerializeField] protected ShootingStrategy _shootingStrategy;
    [SerializeField] protected TypeShootSO typeShoot;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGunPos();
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

    private void FixedUpdate()
    {
        this.Shooting();
    }

    protected virtual void Shooting()
    {
        shootTimer += Time.fixedDeltaTime;
        if (shootTimer < shootDelay) return;
        shootTimer = 0f;
        _shootingStrategy.Shoot(enemyName.ToString(), gunPos, this.transform.parent, typeShoot);

    }
}
