using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject go_tank;
    public GameObject pf_bullet;
    public GameObject go_silo;

    public float spd_move = 5;
    public float spd_rot = 5;

    public float spd_bullet = 1000;
    public float cool_bullet = 0.5f;
    private float cool_current;

    private float h, v;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 미사일 발사 쿨타임 적용
        if (Input.GetKeyDown("space") && cool_current <= 0)
        {
            Shot();
            cool_current = cool_bullet;
        }
        else {
            cool_current -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);

        if (!(h == 0 && v == 0)) {
            go_tank.transform.position += dir * spd_move * Time.deltaTime;
            go_tank.transform.rotation = Quaternion.Lerp(go_tank.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * spd_rot);
        }
    }

    private void Shot() {
        // 포신에 총알 생성
        GameObject go_bullet = Instantiate(pf_bullet);
        go_bullet.transform.position = go_silo.transform.position;

        // 탱크 회전값 기반 발사 방향 설정
        Quaternion angle_bullet = go_tank.transform.rotation;
        Vector3 dir_bullet = angle_bullet * Vector3.forward;

        // 발사 방향으로 힘을 가함
        go_bullet.GetComponent<Rigidbody>().AddForce(spd_bullet * dir_bullet);
    }
}
