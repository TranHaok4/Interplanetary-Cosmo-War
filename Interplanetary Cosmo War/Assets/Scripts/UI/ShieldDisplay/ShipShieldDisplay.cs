using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipShieldDisplay : HaoMonoBehaviour
{
    [SerializeField] protected Slider shipBarSlider;
    [SerializeField] protected Image fill;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipBarSlider();
    }
    protected void LoadShipBarSlider()
    {
        if (shipBarSlider != null) return;
        shipBarSlider = this.GetComponent<Slider>();
        Debug.Log(transform.name + "LoadShipBarSlider");
    }
    public void UpdateShield(int value)
    {
        shipBarSlider.value = value;
    }

    public void SetMaxShield(int value)
    {
        shipBarSlider.maxValue = value;
        shipBarSlider.value = value;
    }

}
