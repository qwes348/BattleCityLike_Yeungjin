using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBullet", 2.0f);
    }

    void DestroyBullet() 
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider collider)
    {
        GameObject go_collider = collider.gameObject;
        if (go_collider.tag == "wall")
        {
            Destroy(gameObject);
        }
        else if (go_collider.tag == "enemy")
        {
            Destroy(gameObject);
        }
    }
}
