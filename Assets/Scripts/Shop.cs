using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    EnemySpawner enemySpawner;
    Score score;

    public float bombs;

    private void Awake()
    {
       
        enemySpawner = FindObjectOfType<EnemySpawner>();
        score = FindObjectOfType<Score>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(bombs);
    }

    public void BuyBomb()
    {
        if(score.currentScore > 500)
        {
            score.currentScore = score.currentScore - 500;
            bombs = bombs + 1;
        }
        
    }

    public void NextWave()
    {
        enemySpawner.wave = enemySpawner.wave + 1;
        enemySpawner.roundStarted = false;
        enemySpawner.pause = false;
    }
}
