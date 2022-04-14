using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHp : MonoBehaviour
{
    public static PlayerHp instance;
    public float currentHp;
    public float maxHp = 10f;

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
        Debug.Log(currentHp);
        if (currentHp == 0)
        {
            
            SceneManager.LoadScene(1);
        }
      //  Debug.Log(currentHp);
    }
}
