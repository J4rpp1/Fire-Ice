using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    PauseMenu pauseMenu;
    public static Score instance;
    public float currentScore;
    public int score;
    public int highScore;
    public float loseScore = 4;
    public TMP_Text scoreText;

    


    private void Awake()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();
        instance = this;
    }
    void Start()
    {
        currentScore = 0;
        highScore = PlayerPrefs.GetInt("highScore");
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
       
        if(!pauseMenu.pause)
        {
            currentScore -= loseScore * Time.deltaTime;
        }
       
        
        
        score = Mathf.RoundToInt(currentScore);

        if(currentScore< 0)
        {
            currentScore = 0;
        }
        
    }
}
