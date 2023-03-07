using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfigSO", menuName = "ScriptableObject/WaveConfigSO")]

public class WaveConfigSO : ScriptableObject
{
    [SerializeField] EnemyEnum enemy_prefabs;
    public string Enemy_Prefabs { get => enemy_prefabs.ToString(); }

    [SerializeField] Transform path_prefab;
    public Transform Path_Prefab { get => path_prefab; }

    [SerializeField] float time_between_Spawn = 0.5f;
    public float Time_Between_Spawn { get => time_between_Spawn; }

    [SerializeField] int number_of_Enemy;
    public int Number_of_Enemy { get => number_of_Enemy; }

    [SerializeField] float move_Speed;
    public float Move_Speed { get => move_Speed; }

    public List<Transform> Get_WayPoints()
    {
        var waveWaypoint = new List<Transform>();
        foreach(Transform child in path_prefab.transform)
        {
            waveWaypoint.Add(child);
        }
        return waveWaypoint;
    }


}
