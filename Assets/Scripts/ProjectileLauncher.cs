using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField]
    private Transform fireTransform;
    [SerializeField]
    private float launchVelocity;
    [SerializeField]
    private Projectile projectilePrefab;
    [SerializeField]
    private LayerMask ignoreLayerMask;

    public void LaunchProjectile()
    {
        Projectile projectileInstance = Instantiate(projectilePrefab, fireTransform.position, fireTransform.rotation);
        projectileInstance.gameObject.SetActive(true);
        projectileInstance.Launch(launchVelocity, ignoreLayerMask);
    }
}
