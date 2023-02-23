using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : HaoMonoBehaviour
{
    [SerializeField] protected BulletDespawn bulletDespawn;
    public BulletDespawn Bullet_Despawn { get => bulletDespawn; }

    [SerializeField] protected BulletDamageSender bulletDamageSender;
    public BulletDamageSender Bullet_DamageSender { get => bulletDamageSender; }

    [SerializeField] protected Transform shooter;
    public Transform Shooter { get => shooter; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletDespawn();
        this.LoadBulletDamageSender();
    }

    protected virtual void LoadBulletDespawn()
    {
        if (bulletDespawn != null) return;
        bulletDespawn = GetComponentInChildren<BulletDespawn>();
        Debug.Log(transform.name + ":LoadBulletDespawn");
    }

    protected virtual void LoadBulletDamageSender()
    {
        if (bulletDamageSender != null) return;
        bulletDamageSender = GetComponentInChildren<BulletDamageSender>();
        Debug.Log(transform.name + ":BulletDamageSender");
    }

    public virtual void SetShooter(Transform shooter)
    {
        this.shooter = shooter;
    }
}
