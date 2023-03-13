using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedObjectsAbility : EnemyAbility
{
    [SerializeField] float timeBetweenSpawn = 0.5f;

    [SerializeField] EnemyEnum objectSpawn;
    [SerializeField] List<Transform> spawnpoints;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPoints();
    }
    protected void LoadSpawnPoints()
    {
        if (spawnpoints.Count != 0) return;
        foreach(Transform child in transform)
        {
            spawnpoints.Add(child);
        }
    }
    public override void InvokeAbility()
    {
        StartCoroutine(SpawnedObjects());
    }
    IEnumerator SpawnedObjects()
    {
        while(true)
        {
            yield return new WaitForSeconds(cooldown);
            for (int index = 0; index < spawnpoints.Count; index++)
            {
                Transform new_children = EnemySpawnerbyObject.Instance.Spawn(objectSpawn.ToString(), spawnpoints[index].transform.position,
                    spawnpoints[index].transform.rotation);
                new_children.gameObject.SetActive(true);
                yield return new WaitForSeconds(timeBetweenSpawn);
            }
        }
    }
}
