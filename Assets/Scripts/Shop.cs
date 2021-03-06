using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] AudioClip clickSound;
    public static Shop instance;
    EnemySpawner enemySpawner;
    PauseMenu pauseMenu;
    Score score;
    BombAttack bombAttack;
    PlayerHp playerHp;
    


    

    private void Awake()
    {
        instance = this;
        playerHp = FindObjectOfType<PlayerHp>();
        bombAttack = FindObjectOfType<BombAttack>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
        score = FindObjectOfType<Score>();
        pauseMenu = FindObjectOfType<PauseMenu>();
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
        if(score.currentScore > 2000)
        {
            SFX.instance.PlayClip(clickSound, 1f);
            score.currentScore = score.currentScore - 2000;
            bombAttack.bombCount = bombAttack.bombCount + 1;
        }
        
    }

    public void BuyHp()
    {
        if (score.currentScore > 2000 && playerHp.currentHp < 5)
        {
            SFX.instance.PlayClip(clickSound, 1f);
            score.currentScore = score.currentScore - 2000;
            playerHp.currentHp = playerHp.currentHp + 1;
        }

    }

    public void NextWave()
    {
        SFX.instance.PlayClip(clickSound, 1f);
        enemySpawner.wave = enemySpawner.wave + 1;
        enemySpawner.roundStarted = false;
        pauseMenu.pause = false;
    }
}
