using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecreateShieldAbility : EnemyAbility
{
    public override void InvokeAbility()
    {
        StartCoroutine(RecreateShield());
    }

    IEnumerator RecreateShield()
    {
        while(true)
        {
            yield return new WaitForSeconds(cooldown);
            if(enemyAbilityCtrl.Enemy_Ctrl.Enemy_Shield.Is_ShieldActive==false)
            {
                enemyAbilityCtrl.Enemy_Ctrl.Enemy_Shield.RecreateShield();
            }
        }
    }

}
