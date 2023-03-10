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
    [SerializeField] protected VFXImpactEnum vfximpactName;
    

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
        if (other.GetComponent<DamageReceiver>() == null) return;

        this.Bullet_Ctrl.Bullet_DamageSender.Send(other.transform);
        CreateImpactFX(other);

    }

    protected virtual void CreateImpactFX(Collider2D other)
    {
        Vector2 hitPos = transform.position;
        Quaternion hitRot = transform.rotation;
        Transform fxImpact= FXSpawner.Instance.Spawn(vfximpactName.ToString(), hitPos, hitRot);
        fxImpact.gameObject.SetActive(true);

    }
}
