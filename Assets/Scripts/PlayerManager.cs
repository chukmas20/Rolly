using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static bool levelStarted;
    public static bool gameOver;

    public GameObject startMenuPanel;
    public GameObject gameOverPanel;

    public static int gems;
    public TextMeshProUGUI gemsText;

    public static int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;


    void Start()
    {
        levelStarted = false;
        gameOver = false;
        Time.timeScale = 1;
        gems = 0;
        score = 0;
        //PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        gemsText.text =(PlayerPrefs.GetInt("TotalGems", 0) + gems).ToString();
        scoreText.text ="Score: " + score.ToString();
        Touchscreen ts = Touchscreen.current;
        if(ts != null && ts.primaryTouch.press.isPressed && !levelStarted)
        {
            levelStarted = true;
            startMenuPanel.SetActive(false);
        }
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            PlayerPrefs.SetInt("TotalGems",PlayerPrefs.GetInt("TotalGems", 0) + gems);
            if(score > PlayerPrefs.GetInt("HighScore"))
            {
                //Display new high score
                highScoreText.text = "New HighScore:" + score;
                //Update the highscore
            }
            this.enabled = false;

        }
    }
}
