using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    private static BulletSpawner instance;

    public static BulletSpawner Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (BulletSpawner.instance != null) Debug.LogError("There is only on Instance");
        BulletSpawner.instance = this;
        
    }
}
