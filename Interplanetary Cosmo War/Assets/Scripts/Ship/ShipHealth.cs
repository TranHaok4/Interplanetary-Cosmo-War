using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : Health
{
    protected override void Awake()
    {
        base.Awake();
        ShipHealthCtrl.Instance.Ship_HealthDisplay.SetMaxHealth(hp_Max);
    }

    public override void Add(int value)
    {
        base.Add(value);
        ShipHealthCtrl.Instance.Ship_HealthDisplay.UpdateHealth(hp);

    }
    public override void Deduct(int value)
    {
        base.Deduct(value);
        ShipHealthCtrl.Instance.Ship_HealthDisplay.UpdateHealth(hp);
    }
}
