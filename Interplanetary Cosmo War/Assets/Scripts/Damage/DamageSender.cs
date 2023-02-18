using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageSender : HaoMonoBehaviour
{
    [Header("DamageSender")]
    [SerializeField] protected int damage = 1;

    public virtual void Send(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponent<DamageReceiver>();
        if (damageReceiver == null) return;
        this.Send(damageReceiver);
    }

    public virtual void Send(DamageReceiver obj)
    {
        obj.Deduct(damage);
    }

  
}
