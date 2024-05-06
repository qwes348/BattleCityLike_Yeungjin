using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;

    public int spawnDestCount;
    public float spawnInterval;
    public GameObject go_enemyPrefab;

    public int currentSpawnedCount;

    private float spawnTimer = 0f;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (GameManager.Instance == null || GameManager.Instance.currentGameState != GameManager.GameState.Playing)
            return;
        if (currentSpawnedCount >= spawnDestCount)
            return;

        if(spawnTimer <= 0f)
        {
            Instantiate(go_enemyPrefab, MapManager.Instance.GetRandomEmptyPoint(), Quaternion.identity);
            spawnTimer = spawnInterval;
            currentSpawnedCount++;

            GameManager.Instance.IncreaseEnemyCount();
            GameCanvasManager.Instance.UpdateEnemyCountImages();
        }
        else
        {
            spawnTimer -= Time.deltaTime;
        }
    }
}
