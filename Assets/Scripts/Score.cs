using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    EnemySpawner enemySpawner;
    public static Score instance;
    public float currentScore;
    public int score;
    public float loseScore = 5;
    public TMP_Text scoreText;
    


    private void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        instance = this;
    }
    void Start()
    {
        currentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
       
        if(!enemySpawner.pause)
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
