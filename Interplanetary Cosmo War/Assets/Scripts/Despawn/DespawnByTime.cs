using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : Despawn
{
    [SerializeField] protected float despawnTime = 5f;
    protected float elapsedTime = 0f;

    protected override void OnEnable()
    {
        base.OnEnable();
        elapsedTime = 0f;
    }

    protected override bool CanDespawn()
    {
        this.elapsedTime += Time.deltaTime;
        if (this.elapsedTime >= this.despawnTime) return true;
        return false;
    }
    
}