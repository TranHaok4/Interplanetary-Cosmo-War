using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageConfigSO", menuName = "ScriptableObject/StageConfigSO")]

public class StageConfigSO : ScriptableObject
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timebetweenStage = 1f;
    public float TimeBetweenStage { get => timebetweenStage; }
    public List<WaveConfigSO> WaveConfigs { get => waveConfigs; }
}