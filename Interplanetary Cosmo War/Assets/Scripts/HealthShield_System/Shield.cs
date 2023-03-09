using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shield : HaoMonoBehaviour
{
    [SerializeField] protected int shieldvalue;
    [SerializeField] protected int max_value;
    [SerializeField] protected bool is_shieldActive;

    [SerializeField] protected Transform model;
    public int CurrentShieldValue { get => shieldvalue; }
    public bool Is_ShieldActive { get => is_shieldActive; }


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
    }
    protected virtual void LoadModel()
    {
        if (model != null) return;
        model = transform.Find("Model");
        Debug.Log(transform.name + ":LoadModel");
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        if(Is_ShieldActive)
        {
            model.gameObject.SetActive(true);
        }
    }

    public virtual void Add(int value)
    {
        shieldvalue += value;
        if (shieldvalue >= max_value) shieldvalue = max_value;
    }
    public virtual void Deduct(int value)
    {
        if(!is_shieldActive)
        {
            return;
        }
        shieldvalue -= value;
        if(shieldvalue<=0)
        {
            is_shieldActive = false;
            model.gameObject.SetActive(false);
        }
    }

    protected virtual void Update()
    {
    }
}
