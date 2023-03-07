using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BurstShooting : ShootingStrategy
{
    [SerializeField] private float delayBurst = 0.05f;

    public override void Shoot(string bulletPrefabName, GunPosition gunPos, Transform shooterTransform, TypeShootSO typeshoot)
    {
        BurstShootingSO new_typeshoot = (BurstShootingSO)typeshoot;
        StartCoroutine(BurstCoroutine(bulletPrefabName, gunPos, shooterTransform, new_typeshoot));
    }

    IEnumerator BurstCoroutine(string bulletPrefabName, GunPosition gunPos, Transform shooterTransform, BurstShootingSO typeshoot)
    {
        int numBurst = typeshoot.Number_BurstBullet;

        while (numBurst > 0)
        {
            // Wait for the burst delay
            yield return new WaitForSeconds(delayBurst);

            // Shoot the burst
            for (int i = 0; i < gunPos.GetSizePos(); i++)
            {
                Vector3 spawnpos = gunPos.GetPos(i).transform.position;
                Quaternion this_rotation = gunPos.GetPos(i).transform.rotation;

                Transform new_bullet = EnemyBulletSpawner.Instance.Spawn(bulletPrefabName, spawnpos, this_rotation);

                BulletCtrl bulletCtrl = new_bullet.GetComponent<BulletCtrl>();
                bulletCtrl.SetShooter(shooterTransform);
                new_bullet.gameObject.SetActive(true);
            }
            numBurst--;
        }
        
    }
}

