using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookOnTargetFly :IBulletStrategyFly
{
    [SerializeField] protected float moveSpeed = 0.05f;
    [SerializeField] protected Transform target;
    [SerializeField] Vector3 direction;
    float angle;
    protected override void OnEnable()
    {
        base.OnEnable();
        target = FindObjectOfType<ShipCtrl>().transform;
         direction = (target.position -transform.position).normalized;
         angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }
    public override void Fly(Transform bullet)
    {
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0,angle+90));

        bullet.position += direction * moveSpeed * Time.deltaTime;
    }
}
