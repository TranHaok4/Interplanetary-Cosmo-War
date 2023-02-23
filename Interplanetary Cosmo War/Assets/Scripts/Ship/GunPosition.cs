using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPosition : HaoMonoBehaviour
{
    [SerializeField] protected List<Transform> gunpos;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGunPos();
    }
    protected virtual void LoadGunPos()
    {
        if (gunpos.Count > 0) return;
        foreach (Transform pos in transform)
        {
            gunpos.Add(pos);
        }
        Debug.Log(transform.name +":LoadGunPos");
    }

    public virtual Transform GetPos(int index)
    {
        return gunpos[index];
    }
    public virtual int GetSizePos()
    {
        return gunpos.Count;
    }
}
