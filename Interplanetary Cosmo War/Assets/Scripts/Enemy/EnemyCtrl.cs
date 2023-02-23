using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : HaoMonoBehaviour
{
    [SerializeField] protected EnemyDespawn enemyDespawn;
    [SerializeField] protected EnemyHealth enemyHealth;
    [SerializeField] protected EnemyShield enemyShield;

    public EnemyDespawn Enemy_Despawn { get => enemyDespawn; }
    public EnemyHealth Enemy_Health { get => enemyHealth; }
    public EnemyShield Enemy_Shield { get => enemyShield; }


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyDespawn();
        this.LoadEnemyHealth();
        this.LoadEnemyShield();

    }

    protected virtual void LoadEnemyHealth()
    {
        if (enemyHealth != null) return;
        enemyHealth = GetComponentInChildren<EnemyHealth>();
        Debug.Log(transform.name + ":LoadEnemyHealth");

    }
    protected virtual void LoadEnemyShield()
    {
        if (enemyShield != null) return;
        enemyShield = GetComponentInChildren<EnemyShield>();
        Debug.Log(transform.name + ":LoadLoadEnemyShield");

    }

    protected virtual void LoadEnemyDespawn()
    {
        if (this.enemyDespawn != null) return;
        enemyDespawn = GetComponentInChildren<EnemyDespawn>();
        Debug.Log(transform.name + ":LoadEnemyDespawn");
    }
}
