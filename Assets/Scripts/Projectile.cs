using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    public UnityEvent<Collider> onHit;

    private float moveDistance;
    private Rigidbody rb;
    private Vector3 lastPosition;
    private LayerMask ignoreLayerMask;

    public void Launch(float velocity, LayerMask ignoreLayerMask)
    {
        rb = GetComponent<Rigidbody>();
        lastPosition = transform.position;
        moveDistance = 0f;
        this.ignoreLayerMask = ignoreLayerMask;
        rb.AddForce(transform.forward * velocity, ForceMode.VelocityChange);
    }

    private void LateUpdate()
    {
        moveDistance += Vector3.Distance(lastPosition, transform.position);
        lastPosition = transform.position;

        if(moveDistance > 50f)
        {
            DestroyProjectile();
        }
    }

    public void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        // other의 레이어가 ignoreLayer마스크에 포함되는 레이어라면 무시함
        if ((ignoreLayerMask & (1 << other.gameObject.layer)) != 0)
            return;

        onHit.Invoke(other);
        DestroyProjectile();
    }
}
