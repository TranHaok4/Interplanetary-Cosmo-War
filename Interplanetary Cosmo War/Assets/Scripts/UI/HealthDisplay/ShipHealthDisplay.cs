using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipHealthDisplay : HaoMonoBehaviour
{
    [SerializeField] protected Slider healtbarSlider;
    [SerializeField] protected Image fill;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHealthBarSlider();
    }
    protected void LoadHealthBarSlider()
    {
        if (healtbarSlider != null) return;
        healtbarSlider = this.GetComponent<Slider>();
        Debug.Log(transform.name + "LoadHealthBarSlider");
    }
    public void UpdateHealth(int value)
    {
        healtbarSlider.value = value;
    }    

    public void SetMaxHealth(int value)
    {
        healtbarSlider.maxValue = value;
        healtbarSlider.value = value;
    }

}
