using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankController : MonoBehaviour
{
    [Header("�̵� �� ȸ�� ����")]
    [SerializeField]
    private float speed_move = 5;
    [SerializeField]
    private float speed_rot = 5;

    [Header("���� ����")]
    [SerializeField]
    private ProjectileLauncher launcher;

    private float h, v;

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
}