using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerbyObject : Spawner
{

    private static EnemySpawnerbyObject instance;

    public static EnemySpawnerbyObject Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (EnemySpawnerbyObject.instance != null) Debug.LogError("There is only an Instance");
        EnemySpawnerbyObject.instance = this;
    }

}
