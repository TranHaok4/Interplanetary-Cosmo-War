using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealthCtrl : HaoMonoBehaviour
{
    private static ShipHealthCtrl instance;
    public static ShipHealthCtrl Instance { get => instance; }

    [SerializeField] protected ShipHealth shipHealth;
    [SerializeField] protected ShipHealthDisplay shipHealthDisplay;

    public ShipHealth Ship_Health { get => shipHealth; }
    public ShipHealthDisplay Ship_HealthDisplay { get => shipHealthDisplay; }

    protected override void Awake()
    {
        base.Awake();
        if (ShipHealthCtrl.instance != null) Debug.LogError("There is only an Instance");
        ShipHealthCtrl.instance = this;

    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.GetShipHealth();
        this.GetShipHealthDisplay();
    }
    protected void GetShipHealth()
    {
        if (shipHealth != null) return;
        shipHealth= FindObjectOfType<ShipHealth>();
        Debug.Log(transform.name + ":GetShipHealth");
    }
    protected void GetShipHealthDisplay()
    {
        if (shipHealthDisplay != null) return;
        shipHealthDisplay = FindObjectOfType<ShipHealthDisplay>();
        Debug.Log(transform.name + ":GetShipHealthDisplay");
    }
}
