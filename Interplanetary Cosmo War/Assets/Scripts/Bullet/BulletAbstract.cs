using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletAbstract : HaoMonoBehaviour
{
    [Header("BulletAbstract")]
    [SerializeField] protected BulletCtrl bulletCtrl;
    public BulletCtrl Bullet_Ctrl { get => bulletCtrl; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
    }
    protected virtual void LoadBulletCtrl()
    {
        if (this.bulletCtrl != null) return;
        bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.Log(transform.name + ":LoadBulletCtrl");
    }
}
