using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPointShooting : ShootingStrategy
{

    public override void Shoot(string bulletPrefabName, GunPosition gunPos, Transform shooterTransform)
    {
        int randIndex = Random.Range(0, gunPos.GetSizePos());
        Debug.Log(randIndex);
        Vector3 spawnpos = gunPos.GetPos(randIndex).transform.position;
        Quaternion this_rotation = gunPos.GetPos(randIndex).transform.rotation;

        Transform new_bullet = EnemyBulletSpawner.Instance.Spawn(bulletPrefabName, spawnpos, this_rotation);

        BulletCtrl bulletCtrl = new_bullet.GetComponent<BulletCtrl>();
        bulletCtrl.SetShooter(shooterTransform);

        new_bullet.gameObject.SetActive(true);

    }
}
