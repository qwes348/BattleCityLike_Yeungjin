using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "enemy_bullet")
        {
            gameObject.SetActive(false);
            Debug.Log("Game Over !!");
        }
    }
}
