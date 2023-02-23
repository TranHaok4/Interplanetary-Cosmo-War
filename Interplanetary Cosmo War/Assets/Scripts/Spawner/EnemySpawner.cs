using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    [SerializeField] List<StageConfigSO> stageConfigs;

    int stage_index = 0;


    protected override void Start()
    {
        base.Start();
        stage_index = 0;
        StartCoroutine(Spawn_AllStage());
    }

    private IEnumerator Spawn_AllStage()
    {
        while(stage_index<stageConfigs.Count)
        {
            var current_Stage = stageConfigs[stage_index];

            yield return StartCoroutine(Spawn_AllWaves(current_Stage));

            yield return new WaitForSeconds(stageConfigs[stage_index].TimeBetweenStage);
            stage_index++;
        }    
    }

    
    private IEnumerator Spawn_AllWaves(StageConfigSO stageconfig)
    {
        int wave_index = 0;
        while (wave_index<stageconfig.WaveConfigs.Count)
        {
            var current_Wave = stageconfig.WaveConfigs[wave_index];
            yield return StartCoroutine(Spawn_All_EnemiesInWave(current_Wave));
            wave_index++;
        }
    }

    private IEnumerator Spawn_All_EnemiesInWave(WaveConfigSO waveconfig)
    {
        for(int enemy_count=0;enemy_count< waveconfig.Number_of_Enemy;enemy_count++)
        {

            Vector3 spawnpos = waveconfig.Get_WayPoints()[0].transform.position;
            Quaternion this_rotation = waveconfig.Get_WayPoints()[0].transform.rotation;

            Transform new_enemy = Spawn(waveconfig.Enemy_Prefabs, spawnpos, this_rotation);
            new_enemy.gameObject.SetActive(true);

            new_enemy.GetComponentInChildren<EnemyPathing>().Set_WaveConfig(waveconfig);

            yield return new WaitForSeconds(waveconfig.Time_Between_Spawn);

        }
    }
}
