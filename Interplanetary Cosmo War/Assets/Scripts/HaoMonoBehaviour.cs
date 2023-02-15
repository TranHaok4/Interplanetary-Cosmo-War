using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HaoMonoBehaviour : MonoBehaviour
{
    protected virtual void OnEnable()
    {
        //todo
    }
    protected virtual void Start()
    {
        //todo
       
    }
    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }
    protected virtual void Awake()
    {
        this.LoadComponents();
    }
    protected virtual void ResetValue()
    {
        //todo
    }

    protected virtual void LoadComponents()
    {
        //todo
    }
}
