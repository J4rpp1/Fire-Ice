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

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
  


    private void Awake()
    {
        instance = this;
        
         
    }
    void Start()
    {
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHp > numOfHearts)
        {
            currentHp = numOfHearts;
        }

        if (currentHp == 0)
        {

            SceneManager.LoadScene(1);
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
        if (currentHp == 0)
        {
            
            SceneManager.LoadScene(1);
        }


      //  Debug.Log(currentHp);
    }
}
