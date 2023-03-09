using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShieldCtrl : HaoMonoBehaviour
{
    private static ShipShieldCtrl instance;
    public static ShipShieldCtrl Instance { get => instance; }

    [SerializeField] protected ShipShield shipShield;
    [SerializeField] protected ShipShieldDisplay shipShieldDisplay;

    public ShipShield Ship_Shield { get => shipShield; }
    public ShipShieldDisplay Ship_ShieldDisplay { get => shipShieldDisplay; }

    protected override void Awake()
    {
        base.Awake();
        if (ShipShieldCtrl.instance != null) Debug.LogError("There is only an Instance");
        ShipShieldCtrl.instance = this;

    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.GetShipShield();
        this.GetShipShieldDisplay();
    }
    protected void GetShipShield()
    {
        if (shipShield != null) return;
        shipShield = FindObjectOfType<ShipShield>();
        Debug.Log(transform.name + ":GetShipShield");
    }
    protected void GetShipShieldDisplay()
    {
        if (shipShieldDisplay != null) return;
        shipShieldDisplay = FindObjectOfType<ShipShieldDisplay>();
        Debug.Log(transform.name + ":GetShipHealthDisplay");
    }
}
