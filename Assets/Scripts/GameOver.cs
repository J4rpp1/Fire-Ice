using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TMP_Text lastScoreText;
    public TMP_Text highScoreText;
    public int highScore;
    public int lastScore;
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore");
        lastScore = PlayerPrefs.GetInt("lastScore");

        lastScoreText.text = "SCORE: " + lastScore.ToString();
        highScoreText.text = "HIGHSCORE:" + highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
