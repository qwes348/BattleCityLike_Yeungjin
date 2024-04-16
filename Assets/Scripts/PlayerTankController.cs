using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankController : MonoBehaviour, IProjectileHitResponder
{
    [Header("이동 및 회전 설정")]
    [SerializeField]
    private float speed_move = 5;
    [SerializeField]
    private float speed_rot = 5;

    [Header("공격 설정")]
    [SerializeField]
    private ProjectileLauncher launcher;

    private float h, v;

    private void Awake()
    {
        launcher.projectileHitResponder = this;
    }

    private void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        if(Input.GetButtonDown("Fire1"))
        {
            launcher.LaunchProjectile();
        }
    }

    private void FixedUpdate()
    {        
        Vector3 dir = new Vector3(h, 0, v);
        dir.Normalize();

        if (dir != Vector3.zero)
        {
            transform.position += dir * speed_move * Time.fixedDeltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.fixedDeltaTime * speed_rot);
        }
    }

    // 인터페이스 구현
    public void OnProjectileHitSomething(Collider other)
    {
        Debug.LogFormat("[{0}] hit [{1}]", transform.name, other.transform.name);
    }
}