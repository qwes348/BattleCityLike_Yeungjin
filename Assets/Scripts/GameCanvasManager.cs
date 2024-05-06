using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvasManager : MonoBehaviour
{
    public static GameCanvasManager Instance { get; private set; }

    public GameObject titlePanel;
    public GameObject playingPanel;
    public GameObject winPanel;
    public GameObject losePanel;

    [Space]
    public List<Image> lifeHeartImages;
    public List<Image> enemyCountImages;

    private void Awake()
    {
        Instance = this;
    }

    public void OnGameStartClicked()
    {
        GameManager.Instance.SetGameState(GameManager.GameState.Playing);
        titlePanel.SetActive(false);
        playingPanel.SetActive(true);
        UpdateLifeHeartImages();
        UpdateEnemyCountImages();
    }    

    public void UpdateLifeHeartImages()
    {
        int count = GameManager.Instance.currentPlayerLife;
        foreach(var img in lifeHeartImages)
        {
            img.gameObject.SetActive(count > 0);
            count--;
        }
    }

    public void UpdateEnemyCountImages()
    {
        int count = EnemySpawner.Instance.spawnDestCount - EnemySpawner.Instance.currentSpawnedCount;
        foreach(var img in enemyCountImages)
        {
            img.gameObject.SetActive(count > 0);
            count--;
        }
    }

    public void ActiveWinPanel()
    {
        playingPanel.SetActive(false);
        winPanel.SetActive(true);
    }

    public void ActiveLosePanel()
    {
        playingPanel.SetActive(false);
        losePanel.SetActive(true);
    }
}
