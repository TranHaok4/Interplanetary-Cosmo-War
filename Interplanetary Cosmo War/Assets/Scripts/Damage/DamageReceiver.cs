using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReceiver : HaoMonoBehaviour
{
    [Header("DamageReceiver")]
    [SerializeField] protected bool isDead;

    protected virtual void Reborn()
    {
    }

    protected virtual void CheckIsDead()
    {

    }
    protected virtual bool IsDead()
    {
        return true;
    }

    public abstract void Add(int value);

    public abstract void Deduct(int value);
    //
    protected abstract void Ondead();
}