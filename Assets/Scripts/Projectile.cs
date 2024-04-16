using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    // 충돌 시 보고할 인터페이스
    public IProjectileHitResponder projectileHitResponder;

    // 이동한 거리 누적값
    private float moveDistance;
    private Rigidbody rb;
    // 직전 프레임에서 위치
    private Vector3 lastPosition;
    // 충돌을 무시할 레이어
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

        // 인터페이스에 충돌 알림
        if (projectileHitResponder != null)
            projectileHitResponder.OnProjectileHitSomething(other);

        DestroyProjectile();
    }
}
