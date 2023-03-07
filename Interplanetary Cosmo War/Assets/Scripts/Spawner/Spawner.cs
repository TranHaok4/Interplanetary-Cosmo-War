using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : HaoMonoBehaviour
{
    [Header("Spawner")]
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;

    [SerializeField] protected Transform holder;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPrefabs();
        this.LoadHolder();
    }

    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.Log(transform.name + ":LoadHolder");
    }

    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        Transform prefabObjs = transform.Find("Prefabs");

        foreach (Transform prefab in prefabObjs)
        {
            prefabs.Add(prefab);
        }
        this.HidePrefabs();
        Debug.Log(transform.name + ":LoadPrefabs");

    }

    protected void HidePrefabs()
    {
        foreach(Transform prefab in prefabs)
        {
            prefab.gameObject.SetActive(false);
        }    
    }

    public virtual Transform Spawn(string prefab,Vector2 spawnpos,Quaternion rotation)
    {
        Transform new_prefab = this.GetObjectFromPool(prefab);
        new_prefab.SetPositionAndRotation(spawnpos, rotation);
        new_prefab.parent = this.holder;
        return new_prefab;
    }

    protected virtual Transform GetObjectFromPool(string prefab_name)
    {
        foreach(Transform poolObj in poolObjs)
        {
            if (poolObj.name == prefab_name)
            {
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }
        }
        return GetObjectbyName(prefab_name);
    }
    protected virtual Transform GetObjectbyName(string prefab_name)
    {
        Transform new_prefab;
        foreach (Transform obj in prefabs)
        {
            if(obj.name==prefab_name)
            {
                new_prefab = Instantiate(obj);
                new_prefab.name = prefab_name;
                return new_prefab;
            }
        }
        return null;
    }

    public virtual void Despawn(Transform obj)
    {
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
    }
}
