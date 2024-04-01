using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject tank;

    public float speed_move = 5;
    public float speed_rot = 5;

    private float h, v;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);

        if (!(h == 0 && v == 0)) {
            tank.transform.position += dir * speed_move * Time.deltaTime;
            tank.transform.rotation = Quaternion.Lerp(tank.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * speed_rot);
        }
    }
}
