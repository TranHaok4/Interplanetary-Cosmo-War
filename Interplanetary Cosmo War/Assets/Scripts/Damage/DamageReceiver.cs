using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReceiver : HaoMonoBehaviour
{
    [Header("DamageReceiver")]
    [SerializeField] protected int hp;
    [SerializeField] protected int hp_Max;

    [SerializeField] protected bool isDead;

    protected virtual void Reborn()
    {
        this.hp = this.hp_Max;
    }

    protected virtual void CheckIsDead()
    {
        if (this.IsDead()) return;
        this.isDead = true;
    }
    protected virtual bool IsDead()
    {
        return this.hp <= 0;
    }

    public virtual void Add(int value)
    {
        hp += value;
        if (hp >= hp_Max) hp = hp_Max;
    }

    public virtual void Deduct(int value)
    {
        hp -= value;
        if (hp <= 0) hp = 0;
    }
    //
    protected abstract void Ondead();
}