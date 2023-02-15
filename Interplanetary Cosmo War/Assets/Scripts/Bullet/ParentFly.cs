using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentFly : HaoMonoBehaviour
{
    [SerializeField] protected int moveSpeed = 5;
    [SerializeField] protected Vector3 direction = Vector3.up;

    protected void Update()
    {
        Fly();
    }

    private void Fly()
    {
        transform.parent.Translate(this.direction * this.moveSpeed * Time.deltaTime);
    }
}
