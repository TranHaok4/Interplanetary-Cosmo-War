using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourCtrl : HaoMonoBehaviour
{
    [SerializeField] EnemyCtrl enemyCtrl;
    public EnemyCtrl Enemy_Ctrl { get => enemyCtrl; }

    [SerializeField] List<IEnemyBehaviour> enemyBehaviours;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyBehaviours();
        this.LoadEnemyCtrl();
    }
    protected void LoadEnemyCtrl()
    {
        if (enemyCtrl != null) return;
        enemyCtrl = this.transform.parent.GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + "LoadEnemyCtrl");
    }
    protected void LoadEnemyBehaviours()
    {
        if (enemyBehaviours.Count!=0) return;
        foreach(Transform child in transform)
        {
            enemyBehaviours.Add(child.GetComponent<IEnemyBehaviour>());
        }
    }

    private void Update()
    {
        foreach(IEnemyBehaviour childBehaviour in enemyBehaviours)
        {
            childBehaviour.InvokeBehavior();
        }    
    }
}
