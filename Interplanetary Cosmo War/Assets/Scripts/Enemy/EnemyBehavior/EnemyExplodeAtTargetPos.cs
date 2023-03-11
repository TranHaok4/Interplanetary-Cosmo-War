using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplodeAtTargetPos : IEnemyBehaviour
{
    [SerializeField] protected Vector3 target;

    [SerializeField] protected float explodingTime = 1F;
    [SerializeField] protected float maxSizeExplode = 1f;
    [SerializeField] protected CircleCollider2D circleCollider2D;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider2D();
    }
    protected void LoadCollider2D()
    {
        if (circleCollider2D != null) return;
        circleCollider2D = GetComponent<CircleCollider2D>();
        Debug.Log(transform.name + "LoadCollider2D");
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        target = FindObjectOfType<ShipCtrl>().transform.position;
    }

    public override void InvokeBehavior()
    {
        if (Vector3.Distance(enemyBehaviourCtrl.Enemy_Ctrl.transform.position,target)<0.1f)
        {
            Explode();
        }
    }
    protected void Explode()
    {
        enemyBehaviourCtrl.Enemy_Ctrl.transform.GetComponent<Animator>().SetTrigger("explode_trigger");
        StartCoroutine(extendingExplodeRadius());

    }

    IEnumerator extendingExplodeRadius()
    {
        float elapsedTime = 0;
        float startRadius = circleCollider2D.radius;
        while (elapsedTime < explodingTime)
        {
            float newRadius = Mathf.Lerp(startRadius, maxSizeExplode, elapsedTime / explodingTime);
            circleCollider2D.radius = newRadius;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        circleCollider2D.radius = maxSizeExplode;
        yield return new WaitForSeconds(0.1f);
        enemyBehaviourCtrl.Enemy_Ctrl.Enemy_Despawn.DespawnObject();

    }
}
