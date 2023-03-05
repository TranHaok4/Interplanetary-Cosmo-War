using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCtrl : HaoMonoBehaviour
{
    [SerializeField] protected ShipHealth shipHealth;
    [SerializeField] protected ShipShield shipShield;

    public ShipHealth Ship_Health { get => shipHealth; }
    public ShipShield Ship_Shield { get => shipShield; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipHealth();
        this.LoadShipShield();
    }
    protected virtual void LoadShipHealth()
    {
        if (shipHealth != null) return;
        shipHealth = this.transform.GetComponentInChildren<ShipHealth>();
        Debug.Log(transform.name + "LoadShipHealth");
    }   
    protected virtual void LoadShipShield()
    {
        if (shipShield != null) return;
        shipShield = this.transform.GetComponentInChildren<ShipShield>();
        Debug.Log(transform.name + "LoadShipShield");
    }
}
