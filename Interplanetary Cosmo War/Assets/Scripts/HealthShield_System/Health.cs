using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : HaoMonoBehaviour
{
    [SerializeField] protected int hp;
    [SerializeField] protected int hp_Max;


    public int GetCurrentHp { get => hp; }
    public int GetMaxHp { get => hp_Max; }

    
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

}
