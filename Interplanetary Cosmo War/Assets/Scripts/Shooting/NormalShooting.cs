using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalShooting :ShootingStrategy
{
    public override  void  Shoot(Transform bulletPrefab, GunPosition gunPos, Transform shooterTransform, TypeShootSO typeshoot)
    {
        Debug.Log("haha");
        for (int index = 0; index < gunPos.GetSizePos(); index++)
        {
            Vector3 spawnpos = gunPos.GetPos(index).transform.position;
            Quaternion this_rotation = gunPos.GetPos(index).transform.rotation;

            Transform new_bullet = EnemyBulletSpawner.Instance.Spawn(bulletPrefab, spawnpos, this_rotation);

            BulletCtrl bulletCtrl = new_bullet.GetComponent<BulletCtrl>();
            bulletCtrl.SetShooter(shooterTransform);

            new_bullet.gameObject.SetActive(true);
        }
    }
}
