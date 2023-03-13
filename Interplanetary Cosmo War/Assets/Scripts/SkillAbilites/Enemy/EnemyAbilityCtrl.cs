using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAbilityCtrl : HaoMonoBehaviour
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    public EnemyCtrl Enemy_Ctrl { get => enemyCtrl; }
    [SerializeField] List<EnemyAbility> enemyAbilities;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
        this.LoadEnemyAbilities();
    }
    protected override void Start()
    {
        base.Start();
        foreach(EnemyAbility ability in enemyAbilities)
        {
            ability.InvokeAbility();
        }
    }
    protected void LoadEnemyCtrl()
    {
        if (enemyCtrl != null) return;
        enemyCtrl = this.transform.parent?.GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + "LoadEnemyCtrl");
    }
    protected void LoadEnemyAbilities()
    {
        if (enemyAbilities.Count != 0) return;
        foreach (Transform child in transform)
        {
            enemyAbilities.Add(child.GetComponent<EnemyAbility>());
        }
    }
}
