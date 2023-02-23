using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipAbstract : HaoMonoBehaviour
{
    [SerializeField] protected ShipCtrl shipCtrl;
    public ShipCtrl Ship_Ctrl { get => shipCtrl; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipCtrl();
    }
    protected virtual void LoadShipCtrl()
    {
        if (shipCtrl != null) return;
        shipCtrl = this.transform.parent.GetComponent<ShipCtrl>();
        Debug.Log(transform.name + ":LoadShipCtrl");
    }
}
