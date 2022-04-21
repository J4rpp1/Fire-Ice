using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUi;
    public bool pause;
    void Start()
    {
        pause = false;
        pauseMenuUi.SetActive(false);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenuUi.SetActive(true);
            pause = true;
            Time.timeScale = 0;
        }
    }

    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        pause = false;
        Time.timeScale = 1;
    }

    public void Quit()
    {
        
    }
}
