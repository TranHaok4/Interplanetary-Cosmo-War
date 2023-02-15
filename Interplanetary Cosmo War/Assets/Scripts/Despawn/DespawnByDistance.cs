using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float disLimit = 70f;
    [SerializeField] protected float current_distance = 0f;

    [SerializeField] protected Transform mainCamera;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = Transform.FindObjectOfType<Camera>().transform;

        
    }
    protected override bool CanDespawn()
    {
        this.current_distance = Vector2.Distance(this.transform.position, this.mainCamera.transform.position);
        if (this.current_distance > this.disLimit) return true;
        return false;
    }

    
}
