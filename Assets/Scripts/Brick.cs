using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider) {
        GameObject go_collider = collider.gameObject;
        if (go_collider.tag == "bullet" || go_collider.tag == "enemy_bullet")
        {
            if (this.gameObject.tag == "heart" && go_collider.tag == "enemy_bullet") 
            {
                Debug.Log("Game Over");
            }
            Destroy(gameObject);
        }
    }
}
