using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : HaoMonoBehaviour
{
    [SerializeField] protected Vector2 targetPosition;
    [SerializeField] protected float move_speed = 0.5f;

    protected void FixedUpdate()
    {
        this.GetTargetPosition();
        this.LookAtTarget();
        this.Moving();
    }

    protected void LookAtTarget()
    {
        Vector2 diff = this.targetPosition - (Vector2)transform.parent.position;
        diff.Normalize();
    }

    protected void Moving()
    {
        Vector2 newpos = 
            Vector2.Lerp(transform.position, targetPosition, this.move_speed * Time.fixedDeltaTime);
        this.transform.parent.position = newpos;
    }

    protected void GetTargetPosition()
    {
        this.targetPosition = InputManager.Instance.MousePosWorld;
    }
}
