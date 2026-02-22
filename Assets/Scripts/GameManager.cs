using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverPanel.SetActive(false); 
        gameWinPanel.SetActive(false);
        PointUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // GameOver && GameWin
        // represet the whole UI Block -> GameObject, not only text
    [SerializeField] private GameObject gameOverPanel, gameWinPanel;
    private bool isOver = false, isWin = false;

    // GameIsOver || GameIsWin
    public void GameIsOver()
    {
        Time.timeScale = 0;  // TẠM DỪNG TOÀN BỘ THỜI GIAN TRONG GAME
        isOver = true;
        gameOverPanel.SetActive(true);
    }
    // RestartGame
    public void RestartGame()
    {
        isOver = false; isWin = false;  
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
    // Menu
    public void MenuGame()
    {   
        isWin = false; isOver = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
    public void GameIsWin()
    {
        Time.timeScale = 0;
        isWin = true;
        gameWinPanel.SetActive(true);
    }

    // for other class to check isOver & isWin status
    public bool IsOver()
    {
        return isOver;
    }
    public bool IsWin()
    {
        return isWin;
    }



    // AddPoint
    private int point = 0; // initialize point
    public void AddPoint(int p)
    {
        if (isOver == false && isWin == false)
        {
            point += p;
            PointUI();
        }

    }
    // PointUI
    [SerializeField] private TextMeshProUGUI pointUI;
    private void PointUI ()
    {
        pointUI.text = point.ToString();
    }
        
        
}
