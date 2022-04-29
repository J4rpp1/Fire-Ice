using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] AudioClip clickSound;
    public GameObject info;
 

    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void StartGame()
    {
        SFX.instance.PlayClip(clickSound, 1f);
        SceneManager.LoadScene(1);
    }

    public void OpenInfo()
    {
        SFX.instance.PlayClip(clickSound, 1f);
        info.SetActive(true);
    }
    
    public void CloseInfo()
    {
        SFX.instance.PlayClip(clickSound, 1f);
        info.SetActive(false);
    }
}
