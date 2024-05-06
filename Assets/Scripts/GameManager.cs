using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public enum GameState { None, Playing, Win, Defeat }

    public GameState currentGameState;

    [SerializeField]
    private PlayerTank playerTank;
    public int currentPlayerLife;

    private int currentActiveEnemiesCount;

    private void Awake()
    {
        Instance = this;
        playerTank.gameObject.SetActive(false);
    }

    private void Start()
    {
        currentPlayerLife = 3;
    }    

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnPlayerDead()
    {
        currentPlayerLife--;
        if(currentPlayerLife <= 0)
        {
            SetGameState(GameState.Defeat);
        }
        else
        {
            playerTank.Respawn();
        }

        GameCanvasManager.Instance.UpdateLifeHeartImages();
    }

    public void IncreaseEnemyCount()
    {
        currentActiveEnemiesCount++;
    }

    public void OnEnemyDead()
    {
        currentActiveEnemiesCount--;

        if(currentActiveEnemiesCount <= 0)
        {
            SetGameState(GameState.Win);
        }    
    }

    public void SetGameState(GameState newState)
    {
        switch (newState)
        {
            case GameState.Playing:
                MapManager.Instance.SpawnMap(0);
                playerTank.gameObject.SetActive(true);
                break;
            case GameState.Win:
                GameCanvasManager.Instance.ActiveWinPanel();
                break;
            case GameState.Defeat:
                GameCanvasManager.Instance.ActiveLosePanel();
                break;
        }

        currentGameState = newState;
    }
}
