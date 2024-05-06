using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int spawnDestCount;
    public float spawnInterval;
    public GameObject go_enemyPrefab;

    [Header("È®ÀÎ¿ë")]
    [SerializeField]
    private int currentSpawnedCount;

    private float spawnTimer = 0f;

    private void Update()
    {
        if(spawnTimer <= 0f)
        {
            Instantiate(go_enemyPrefab, MapManager.Instance.GetRandomEmptyPoint(), Quaternion.identity);
            spawnTimer = spawnInterval;
        }
        else
        {
            spawnTimer -= Time.deltaTime;
        }
    }
}
