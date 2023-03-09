using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ShipDamageReceiver : DamageReceiver
{
    [Header("ShipDamageReceiver")]
    [SerializeField] protected BoxCollider2D boxCollider2D;
    [SerializeField] protected ShipCtrl shipCtrl;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider2D();
        this.LoadShipCtrl();
    }
    protected virtual void LoadCollider2D()
    {
        if (boxCollider2D != null) return;
        boxCollider2D = this.GetComponent<BoxCollider2D>();
        boxCollider2D.isTrigger = true;
        Debug.Log(transform.name + "LoadCollder2D");
    }

    protected virtual void LoadShipCtrl()
    {
        if (shipCtrl != null) return;
        shipCtrl = this.transform.parent.GetComponent<ShipCtrl>();
        Debug.Log(transform.name + "LoadShipCtrl");
    }

    public override void Deduct(int value)
    {
        shipCtrl.Ship_Shield.Deduct(value);
        if (!checkIsShieldEnble())
        {
            shipCtrl.Ship_Health.Deduct(value);
        }
    }

    public override void Add(int value)
    {
        shipCtrl.Ship_Health.Add(value);
    }

    protected bool checkIsShieldEnble()
    {
        return shipCtrl.Ship_Shield.Is_ShieldActive;
    }

    protected override void Ondead()
    {
        throw new System.NotImplementedException();
    }

}

