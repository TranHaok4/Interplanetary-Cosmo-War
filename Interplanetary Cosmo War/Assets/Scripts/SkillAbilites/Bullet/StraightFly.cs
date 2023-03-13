using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightFly :IBulletStrategyFly
{
    [SerializeField] protected int moveSpeed = 5;
    [SerializeField] protected Vector3 direction = Vector3.up;

    public override void Fly(Transform bullet)
    {
        bullet.Translate(this.direction * this.moveSpeed * Time.deltaTime);
    }
}
