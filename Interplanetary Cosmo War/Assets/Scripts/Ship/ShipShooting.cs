using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : HaoMonoBehaviour
{
    [SerializeField] protected Transform bullet_Prefab;

    [SerializeField] protected float shootDelay = 0.2f;
    [SerializeField] protected float shootTimer = 0f;

    [SerializeField] protected GunPosition gunPos;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGunPos();
    }

    protected void LoadGunPos()
    {
        if(gunPos!=null)
        {
            return;
        }
        gunPos = this.GetComponentInChildren<GunPosition>();
        Debug.Log(transform.name+":LoadGunPos");

    }

    protected void FixedUpdate()
    {
        this.Shooting();
    }

    protected virtual void Shooting()
    {
        shootTimer += Time.fixedDeltaTime;
        if (shootTimer < shootDelay) return;
        shootTimer = 0f;

        Vector3 spawnpos = this.gunPos.GetPos(0).transform.position;
        Quaternion this_rotation = this.gunPos.GetPos(0).transform.rotation;

        Transform new_bullet = BulletSpawner.Instance.Spawn(bullet_Prefab, spawnpos, this_rotation);
        new_bullet.gameObject.SetActive(true);
        BulletCtrl bulletCtrl = new_bullet.GetComponent<BulletCtrl>();
        bulletCtrl.SetShooter(transform.parent);
    }
}
