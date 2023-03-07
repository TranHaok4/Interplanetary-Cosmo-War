using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXDespawn : DespawnByTime
{
    [SerializeField] protected Spawner vfxSpawner;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadVFXSpawner();
    }

    protected virtual void LoadVFXSpawner()
    {
        if (vfxSpawner != null) return;
        vfxSpawner = transform.parent.parent.parent.GetComponent<Spawner>();
        Debug.Log(transform.name + ":LoadSpawner");
    }
    public override void DespawnObject()
    {
        vfxSpawner.Despawn(this.transform.parent);

    }
}
