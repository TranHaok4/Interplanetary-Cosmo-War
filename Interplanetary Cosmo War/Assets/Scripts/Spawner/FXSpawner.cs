using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : Spawner
{
    private static FXSpawner instance;

    public static FXSpawner Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (FXSpawner.instance != null) Debug.LogError("There is only one Instance of FXSpawner");
        FXSpawner.instance = this;
    }
}