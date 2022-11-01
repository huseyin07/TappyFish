using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject GetReady;
    [SerializeField] GameObject score;
    [SerializeField] Score ScoreScript;

    public static Vector2 ButtonLeft;
    public static bool gameOver;
    public static int gameScore;
    public static bool gameStarted;
    
    private void Awake()
    {
        ButtonLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
    }
    void Start()
    {
        gameOver = false;
        gameStarted = false;
    }
    public void GameHasStarted()
    {
        gameStarted = true;
        GetReady.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
        score.SetActive(false);
        gameScore = ScoreScript.GetScore();
    }
   
}
