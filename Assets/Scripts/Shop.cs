using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Shop instance;
    EnemySpawner enemySpawner;
    Score score;
    BombAttack bombAttack;
    


    

    private void Awake()
    {
        instance = this;
        bombAttack = FindObjectOfType<BombAttack>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
        score = FindObjectOfType<Score>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void BuyBomb()
    {
        if(score.currentScore > 500)
        {
            score.currentScore = score.currentScore - 500;
            bombAttack.bombCount = bombAttack.bombCount + 1;
        }
        
    }

    public void NextWave()
    {
        enemySpawner.wave = enemySpawner.wave + 1;
        enemySpawner.roundStarted = false;
        enemySpawner.pause = false;
    }
}
