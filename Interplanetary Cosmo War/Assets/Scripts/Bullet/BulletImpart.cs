using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BulletImpart : BulletAbstract
{
    [Header("BulletImpart")]
    [SerializeField] protected BoxCollider2D boxCollider;
    [SerializeField] protected Rigidbody2D _rigibody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBoxCollider();
        this.LoadRigibody();
    }
    protected virtual void LoadBoxCollider()
    {
        if (boxCollider != null) return;
        boxCollider = this.GetComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;
        Debug.Log(transform.name +":LoadBoxCollider");
    }

    protected virtual void LoadRigibody()
    {
        if (_rigibody != null) return;
        _rigibody = this.GetComponent<Rigidbody2D>();
        _rigibody.isKinematic = true;
        Debug.Log(transform.name + ":LoadRigibody");
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.parent.gameObject.name == this.bulletCtrl.Shooter.name) return; 
        this.Bullet_Ctrl.Bullet_DamageSender.Send(other.transform);
    }
}
