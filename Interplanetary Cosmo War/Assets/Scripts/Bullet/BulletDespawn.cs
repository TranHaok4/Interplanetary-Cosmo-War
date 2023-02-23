using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : DespawnByDistance
{
    [SerializeField] protected Spawner bullet_spawner;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
    }
    protected void LoadSpawner()
    {
        if (bullet_spawner != null) return;
        bullet_spawner = transform.parent.parent.parent.GetComponent<Spawner>();
        Debug.Log(transform.name +":LoadSpawner");
    }
    public override void DespawnObject()
    {
        bullet_spawner.Despawn(this.transform.parent);
    }
}
