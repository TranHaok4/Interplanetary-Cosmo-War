using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawn : DespawnByDistance
{
    [SerializeField] protected Spawner enemySpawner;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySpawner();
    }
    protected void LoadEnemySpawner()
    {
        if (enemySpawner != null) return;
        enemySpawner = transform.parent?.parent?.parent?.GetComponent<Spawner>();
        Debug.Log(transform.name + ":LoadSpawner");


    }
    public override void DespawnObject()
    {
        enemySpawner.Despawn(this.transform.parent);
    }
}
