using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShield : Shield
{

    protected override void Awake()
    {
        base.Awake();
        ShipShieldCtrl.Instance.Ship_ShieldDisplay.SetMaxShield(max_value);
    }

    public override void Add(int value)
    {
        base.Add(value);
        ShipShieldCtrl.Instance.Ship_ShieldDisplay.UpdateShield(shieldvalue);
    }
    public override void Deduct(int value)
    {
        base.Deduct(value);
        ShipShieldCtrl.Instance.Ship_ShieldDisplay.UpdateShield(shieldvalue);
    }
}
