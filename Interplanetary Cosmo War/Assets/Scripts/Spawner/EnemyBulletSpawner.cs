using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawner : Spawner
{
    private static EnemyBulletSpawner instance;

    public static EnemyBulletSpawner Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (EnemyBulletSpawner.instance != null) Debug.LogError("There is only an Instance");
        EnemyBulletSpawner.instance = this;
    }
}
