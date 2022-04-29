using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    public static PlayerHp instance;
    
    public int currentHp;
    public int maxHp = 10;
    public int numOfHearts;

    Score score;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public AudioSource hurtSound;
  


    private void Awake()
    {
       
        instance = this;
        
         
    }
    void Start()
    {
        score = FindObjectOfType<Score>();
        currentHp = maxHp;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHp > numOfHearts)
        {
            currentHp = numOfHearts;
        }

        if (currentHp < 1)
        {
            if(score.score > score.highScore)
            {
                PlayerPrefs.SetInt("highScore", score.score);
                PlayerPrefs.SetInt("lastScore", score.score);
            }
            else
            {
                PlayerPrefs.SetInt("lastScore", score.score);
            }
            
            SceneManager.LoadScene(2);
        }


        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < currentHp)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
       /* if (currentHp == 0)
        {
            
            SceneManager.LoadScene(1);
        }*/


      //  Debug.Log(currentHp);
    }
}
