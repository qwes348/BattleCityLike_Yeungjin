using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : MonoBehaviour
{
    private Vector3 spawnPos;

    private void Awake()
    {
        spawnPos = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "enemy_bullet")
        {
            gameObject.SetActive(false);
            GameManager.Instance.OnPlayerDead();
        }
    }

    public void Respawn()
    {
        transform.position = spawnPos;
        gameObject.SetActive(true);
    }
}
