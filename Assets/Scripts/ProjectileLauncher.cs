using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    // 충돌 시 보고할 인터페이스(투사체 인스턴스에 전달)
    public IProjectileHitResponder projectileHitResponder;

    // 발사 위치(rotation값도 중요함)
    [SerializeField]
    private Transform fireTransform;
    // 발사 속도(힘)
    [SerializeField]
    private float launchVelocity;
    // 투사체 프리팹
    [SerializeField]
    private Projectile projectilePrefab;
    // 충돌 무시할 레이어(투사체 인스턴스에 전달)
    [SerializeField]
    private LayerMask ignoreLayerMask;    

    public void LaunchProjectile()
    {
        Projectile projectileInstance = Instantiate(projectilePrefab, fireTransform.position, fireTransform.rotation);
        projectileInstance.projectileHitResponder = this.projectileHitResponder;
        projectileInstance.gameObject.SetActive(true);
        projectileInstance.Launch(launchVelocity, ignoreLayerMask);
    }
}
