using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Vector2 bottomleft;
    public static bool gameOver;
    public GameObject gameOverPanel;
    public static bool gameStarted;
    public GameObject GetReady;
    public static int gameScore;
    public GameObject score;



    private void Awake()
    {
        bottomleft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)); // Kameranýn Sol alt köþesini iþaret ettik, LeftMovement.cs içerisinde kullandýk        
    }

    public void RestartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

    public void GameOver()
    {
        gameOver=true;
        gameOverPanel.SetActive(true); // Score tablosunu görünür yapýyoruz
        score.SetActive(false);
        gameScore = score.GetComponent<Score>().GetScore();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
