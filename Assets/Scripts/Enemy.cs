using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    public Transform target;
    public Vector3 destination;
    public NavMeshAgent agent;    

    [Space]
    public GameObject go_silo;
    public GameObject pf_bullet;
    public float spd_bullet = 1000;
    public float cool_bullet = 0.5f;
    private float cool_current;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
        cool_current = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(destination, target.position) > 1.0f)
        {
            destination = target.position;
            agent.destination = destination;
        }

        if(Vector3.Distance(target.position, transform.position) <= agent.stoppingDistance)
        {
            // �̻��� �߻� ��Ÿ�� ����
            if (cool_current <= 0)
            {
                Shot();
                cool_current = cool_bullet;
            }
            else
            {
                cool_current -= Time.deltaTime;
            }
        }
    }

    private void Shot()
    {
        // ���ſ� �Ѿ� ����
        GameObject go_bullet = Instantiate(pf_bullet);
        go_bullet.transform.position = go_silo.transform.position;

        // ��ũ ȸ���� ��� �߻� ���� ����
        Quaternion angle_bullet = transform.rotation;
        Vector3 dir_bullet = angle_bullet * Vector3.forward;

        // �߻� �������� ���� ����
        go_bullet.GetComponent<Rigidbody>().AddForce(spd_bullet * dir_bullet);
    }
}
