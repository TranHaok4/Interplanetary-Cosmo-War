using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnChildrenBehaviour : IEnemyBehaviour
{
    [SerializeField] protected EnemyEnum children;
    [SerializeField] protected float timeDelaySpawn = 4f;
    [SerializeField] protected float currentTimeDelaySpawn = 0;
    protected override void OnEnable()
    {
        base.OnEnable();
        currentTimeDelaySpawn = 0;
    }
    public override void InvokeBehavior()
    {
        SpawneChildren();
    }

    protected void SpawneChildren()
    {
        currentTimeDelaySpawn += Time.deltaTime;
        if (currentTimeDelaySpawn < timeDelaySpawn) return;
        currentTimeDelaySpawn = 0;

        Transform new_children= EnemySpawnerbyObject.Instance.Spawn(children.ToString(), transform.position, transform.rotation);
        new_children.gameObject.SetActive(true);
    }

}
