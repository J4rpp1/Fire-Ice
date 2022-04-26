using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;

    PauseMenu pauseMenu;
    FollowMouse followMouse;

    public AudioSource mainTheme;
    public AudioSource bossTheme;

    public TMP_Text bossText;
    public TMP_Text waveText;
    public TMP_Text countText;

    public GameObject shopMenu;
    public GameObject[] mediumSpawnPoints;
    public GameObject bossSpawnPoint;
    public GameObject littleSpawnPoint;
    public GameObject[] flyingSpawnPoints;
    public int selected;

    public GameObject[] mediumEnemy;
    public GameObject[] littleEnemy;
    public GameObject[] flyingEnemy;
    public GameObject bossEnemy;

    public int wave;
    public int enemiesKilled;
    public int bossesKilled;
    public bool enableBossText;
    public bool shopOpen;
    
    public bool roundStarted;


    public bool completedWave1;


    private void Awake()
    {
        instance = this;
        followMouse = FindObjectOfType<FollowMouse>();
        pauseMenu = FindObjectOfType<PauseMenu>();
    }
    void Start()
    {
        Time.timeScale = 1;
        mainTheme.Play();
        waveText.text = "Wave 1";
        wave = 1;
        
        Cursor.visible = false;
        enableBossText = true;
        StartCoroutine(Enemyspawner1());
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesKilled == 12 && enableBossText && completedWave1 == false)
        {
            StartCoroutine(Boss());
        }

        if (enemiesKilled == 16 && enableBossText && wave == 2)
        {
            StartCoroutine(Boss());
        }

        if (enemiesKilled == 23 && enableBossText && wave == 3)
        {
            StartCoroutine(Boss());
        }

        if (enemiesKilled == 31 && enableBossText && wave == 4)
        {
            StartCoroutine(Boss());
        }


        if (enemiesKilled == 39 && enableBossText && wave == 5)
        {
            StartCoroutine(Boss());
        }
        


        if (bossesKilled == 1)
        {
            bossTheme.Stop();
            mainTheme.Play();
            completedWave1 = true;
            enableBossText = true;
            followMouse.crosshair.SetActive(false);
            shopMenu.SetActive(true);
            Cursor.visible = true;
            shopOpen = true;
            pauseMenu.pause = true;
            bossesKilled = 0;
        }
        if (wave == 2 && !roundStarted)
        {
            
            waveText.text = "Wave " + wave.ToString();
            StartCoroutine(Enemyspawner2());
        }
        if (wave == 3 && !roundStarted)
        {
            waveText.text = "Wave " + wave.ToString();
            StartCoroutine(Enemyspawner3());
        }
        if (wave == 4 && !roundStarted)
        {
            waveText.text = "Wave " + wave.ToString();
            StartCoroutine(Enemyspawner4());
        }
        if (wave == 5 && !roundStarted)
        {
            waveText.text = "Wave " + wave.ToString();
            StartCoroutine(Enemyspawner5());
        }
    }

    #region Wave system

    //wave 1
    IEnumerator Enemyspawner1()
    {
        int spawn = Random.Range(0, mediumSpawnPoints.Length); //sets random spawn point
        int select = Random.Range(0, mediumEnemy.Length);      //selects ice or fire enemy
        GameObject.Instantiate(mediumEnemy[select], mediumSpawnPoints[spawn].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);
       
        int spawn2 = Random.Range(0, mediumSpawnPoints.Length);
        int select2 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select2], mediumSpawnPoints[spawn2].transform.position, Quaternion.identity); 
        yield return new WaitForSeconds(2);

        int spawn3 = Random.Range(0, mediumSpawnPoints.Length);
        int select3 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select3], mediumSpawnPoints[spawn3].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        int spawn4 = Random.Range(0, mediumSpawnPoints.Length);
        int select4 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select4], mediumSpawnPoints[spawn4].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        GameObject.Instantiate(mediumEnemy[select], mediumSpawnPoints[spawn].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        GameObject.Instantiate(mediumEnemy[select3], mediumSpawnPoints[spawn3].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        GameObject.Instantiate(mediumEnemy[select2], mediumSpawnPoints[spawn2].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        GameObject.Instantiate(mediumEnemy[select4], mediumSpawnPoints[spawn4].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        int select7 = Random.Range(0, littleEnemy.Length);
        GameObject.Instantiate(littleEnemy[select7], littleSpawnPoint.transform.position, Quaternion.identity);  //Spawnaa pieni vihollinen

        int spawn5 = Random.Range(0, mediumSpawnPoints.Length);
        int select5 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select5], mediumSpawnPoints[spawn5].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        GameObject.Instantiate(mediumEnemy[select3], mediumSpawnPoints[spawn3].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        int spawn6 = Random.Range(0, mediumSpawnPoints.Length);
        int select6 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select6], mediumSpawnPoints[spawn6].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        
    }

    //wave 2
    IEnumerator Enemyspawner2()
    {
        shopMenu.SetActive(false);
        Cursor.visible = false;
        followMouse.crosshair.SetActive(true);
        roundStarted = true;
        int spawn = Random.Range(0, mediumSpawnPoints.Length); //sets random spawn point
        int select = Random.Range(0, mediumEnemy.Length);      //selects ice or fire enemy
        GameObject.Instantiate(mediumEnemy[select], mediumSpawnPoints[spawn].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);

        int spawn2 = Random.Range(0, mediumSpawnPoints.Length);
        int select2 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select2], mediumSpawnPoints[spawn2].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        int spawn3 = Random.Range(0, mediumSpawnPoints.Length);
        int select3 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select3], mediumSpawnPoints[spawn3].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        int select10 = Random.Range(0, littleEnemy.Length);
        GameObject.Instantiate(littleEnemy[select10], littleSpawnPoint.transform.position, Quaternion.identity);  //Spawnaa pieni vihollinen

        int spawn4 = Random.Range(0, mediumSpawnPoints.Length);
        int select4 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select4], mediumSpawnPoints[spawn4].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        GameObject.Instantiate(mediumEnemy[select], mediumSpawnPoints[spawn].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        GameObject.Instantiate(mediumEnemy[select3], mediumSpawnPoints[spawn3].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        GameObject.Instantiate(mediumEnemy[select2], mediumSpawnPoints[spawn2].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        GameObject.Instantiate(mediumEnemy[select4], mediumSpawnPoints[spawn4].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(3);

        int select8 = Random.Range(0, littleEnemy.Length);
        GameObject.Instantiate(littleEnemy[select8], littleSpawnPoint.transform.position, Quaternion.identity);  //Spawnaa pieni vihollinen

        int spawn5 = Random.Range(0, mediumSpawnPoints.Length);
        int select5 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select5], mediumSpawnPoints[spawn5].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        GameObject.Instantiate(mediumEnemy[select3], mediumSpawnPoints[spawn3].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        int spawn6 = Random.Range(0, mediumSpawnPoints.Length);
        int select6 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select6], mediumSpawnPoints[spawn6].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        GameObject.Instantiate(mediumEnemy[select2], mediumSpawnPoints[spawn2].transform.position, Quaternion.identity);

        GameObject.Instantiate(mediumEnemy[select], mediumSpawnPoints[spawn].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        int select9 = Random.Range(0, littleEnemy.Length);
        GameObject.Instantiate(littleEnemy[select9], littleSpawnPoint.transform.position, Quaternion.identity);


    }

    //wave 3
    IEnumerator Enemyspawner3()
    {
        shopMenu.SetActive(false);
        Cursor.visible = false;
        followMouse.crosshair.SetActive(true);
        roundStarted = true;
        int spawn = Random.Range(0, mediumSpawnPoints.Length); //sets random spawn point
        int select = Random.Range(0, mediumEnemy.Length);      //selects ice or fire enemy
        GameObject.Instantiate(mediumEnemy[select], mediumSpawnPoints[spawn].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);

        int spawn2 = Random.Range(0, mediumSpawnPoints.Length);
        int select2 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select2], mediumSpawnPoints[spawn2].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);

        int spawnF = Random.Range(0, flyingSpawnPoints.Length);
        int selectF = Random.Range(0, flyingEnemy.Length);
        GameObject.Instantiate(flyingEnemy[selectF], flyingSpawnPoints[spawnF].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        int spawn3 = Random.Range(0, mediumSpawnPoints.Length);
        int select3 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select3], mediumSpawnPoints[spawn3].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);

        int select10 = Random.Range(0, littleEnemy.Length);
        GameObject.Instantiate(littleEnemy[select10], littleSpawnPoint.transform.position, Quaternion.identity);  //Spawnaa pieni vihollinen

        int spawn4 = Random.Range(0, mediumSpawnPoints.Length);
        int select4 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select4], mediumSpawnPoints[spawn4].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        GameObject.Instantiate(mediumEnemy[select], mediumSpawnPoints[spawn].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        GameObject.Instantiate(mediumEnemy[select3], mediumSpawnPoints[spawn3].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        int spawnF2 = Random.Range(0, flyingSpawnPoints.Length);
        int selectF2 = Random.Range(0, flyingEnemy.Length);
        GameObject.Instantiate(flyingEnemy[selectF2], flyingSpawnPoints[spawnF2].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);

        int spawnF3 = Random.Range(0, flyingSpawnPoints.Length);
        int selectF3 = Random.Range(0, flyingEnemy.Length);
        GameObject.Instantiate(flyingEnemy[selectF3], flyingSpawnPoints[spawnF3].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);

        GameObject.Instantiate(mediumEnemy[select2], mediumSpawnPoints[spawn2].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        GameObject.Instantiate(mediumEnemy[select4], mediumSpawnPoints[spawn4].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(3);

        int select8 = Random.Range(0, littleEnemy.Length);
        GameObject.Instantiate(littleEnemy[select8], littleSpawnPoint.transform.position, Quaternion.identity);  //Spawnaa pieni vihollinen

        int spawn5 = Random.Range(0, mediumSpawnPoints.Length);
        int select5 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select5], mediumSpawnPoints[spawn5].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        GameObject.Instantiate(mediumEnemy[select3], mediumSpawnPoints[spawn3].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        int spawn6 = Random.Range(0, mediumSpawnPoints.Length);
        int select6 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select6], mediumSpawnPoints[spawn6].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        GameObject.Instantiate(mediumEnemy[select2], mediumSpawnPoints[spawn2].transform.position, Quaternion.identity);

        GameObject.Instantiate(mediumEnemy[select], mediumSpawnPoints[spawn].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        int select9 = Random.Range(0, littleEnemy.Length);
        GameObject.Instantiate(littleEnemy[select9], littleSpawnPoint.transform.position, Quaternion.identity);

        int spawn11 = Random.Range(0, mediumSpawnPoints.Length); 
        int select11 = Random.Range(0, mediumEnemy.Length);      
        GameObject.Instantiate(mediumEnemy[select11], mediumSpawnPoints[spawn11].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);

        int spawn12 = Random.Range(0, mediumSpawnPoints.Length);
        int select12 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select12], mediumSpawnPoints[spawn12].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);


        GameObject.Instantiate(mediumEnemy[select3], mediumSpawnPoints[spawn3].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        GameObject.Instantiate(mediumEnemy[select3], mediumSpawnPoints[spawn3].transform.position, Quaternion.identity);

    }

    //wave 4
    IEnumerator Enemyspawner4()
    {
        shopMenu.SetActive(false);
        Cursor.visible = false;
        followMouse.crosshair.SetActive(true);
        roundStarted = true;
        int spawn = Random.Range(0, mediumSpawnPoints.Length); //sets random spawn point
        int select = Random.Range(0, mediumEnemy.Length);      //selects ice or fire enemy
        GameObject.Instantiate(mediumEnemy[select], mediumSpawnPoints[spawn].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);

        int spawn2 = Random.Range(0, mediumSpawnPoints.Length);
        int select2 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select2], mediumSpawnPoints[spawn2].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);

        int spawnF = Random.Range(0, flyingSpawnPoints.Length);
        int selectF = Random.Range(0, flyingEnemy.Length);
        GameObject.Instantiate(flyingEnemy[selectF], flyingSpawnPoints[spawnF].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        int spawn3 = Random.Range(0, mediumSpawnPoints.Length);
        int select3 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select3], mediumSpawnPoints[spawn3].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);

        int select10 = Random.Range(0, littleEnemy.Length);
        GameObject.Instantiate(littleEnemy[select10], littleSpawnPoint.transform.position, Quaternion.identity);  //Spawnaa pieni vihollinen

        int spawn4 = Random.Range(0, mediumSpawnPoints.Length);
        int select4 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select4], mediumSpawnPoints[spawn4].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        GameObject.Instantiate(mediumEnemy[select], mediumSpawnPoints[spawn].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        GameObject.Instantiate(mediumEnemy[select3], mediumSpawnPoints[spawn3].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        int spawnF2 = Random.Range(0, flyingSpawnPoints.Length);
        int selectF2 = Random.Range(0, flyingEnemy.Length);
        GameObject.Instantiate(flyingEnemy[selectF2], flyingSpawnPoints[spawnF2].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);

        int spawnF3 = Random.Range(0, flyingSpawnPoints.Length);
        int selectF3 = Random.Range(0, flyingEnemy.Length);
        GameObject.Instantiate(flyingEnemy[selectF3], flyingSpawnPoints[spawnF3].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);

        GameObject.Instantiate(mediumEnemy[select2], mediumSpawnPoints[spawn2].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        GameObject.Instantiate(mediumEnemy[select4], mediumSpawnPoints[spawn4].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(3);

        int select8 = Random.Range(0, littleEnemy.Length);
        GameObject.Instantiate(littleEnemy[select8], littleSpawnPoint.transform.position, Quaternion.identity);  //Spawnaa pieni vihollinen

        int spawn5 = Random.Range(0, mediumSpawnPoints.Length);
        int select5 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select5], mediumSpawnPoints[spawn5].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        GameObject.Instantiate(mediumEnemy[select3], mediumSpawnPoints[spawn3].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        int spawn6 = Random.Range(0, mediumSpawnPoints.Length);
        int select6 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select6], mediumSpawnPoints[spawn6].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        GameObject.Instantiate(mediumEnemy[select2], mediumSpawnPoints[spawn2].transform.position, Quaternion.identity);

        GameObject.Instantiate(mediumEnemy[select], mediumSpawnPoints[spawn].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        int select9 = Random.Range(0, littleEnemy.Length);
        GameObject.Instantiate(littleEnemy[select9], littleSpawnPoint.transform.position, Quaternion.identity);

        int spawn11 = Random.Range(0, mediumSpawnPoints.Length);
        int select11 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select11], mediumSpawnPoints[spawn11].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);

        int spawnF4 = Random.Range(0, flyingSpawnPoints.Length);
        int selectF4 = Random.Range(0, flyingEnemy.Length);
        GameObject.Instantiate(flyingEnemy[selectF4], flyingSpawnPoints[spawnF4].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);

        int spawn12 = Random.Range(0, mediumSpawnPoints.Length);
        int select12 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select12], mediumSpawnPoints[spawn12].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);


        GameObject.Instantiate(mediumEnemy[select3], mediumSpawnPoints[spawn3].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        GameObject.Instantiate(mediumEnemy[select3], mediumSpawnPoints[spawn3].transform.position, Quaternion.identity);

        int spawn13 = Random.Range(0, mediumSpawnPoints.Length);
        int select13 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select13], mediumSpawnPoints[spawn13].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);


        int select14 = Random.Range(0, littleEnemy.Length);
        GameObject.Instantiate(littleEnemy[select14], littleSpawnPoint.transform.position, Quaternion.identity);

        GameObject.Instantiate(mediumEnemy[select], mediumSpawnPoints[spawn].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        GameObject.Instantiate(mediumEnemy[select3], mediumSpawnPoints[spawn3].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);

        GameObject.Instantiate(mediumEnemy[select6], mediumSpawnPoints[spawn6].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        int spawnF5 = Random.Range(0, flyingSpawnPoints.Length);
        int selectF5 = Random.Range(0, flyingEnemy.Length);
        GameObject.Instantiate(flyingEnemy[selectF5], flyingSpawnPoints[spawnF5].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);

        int spawn15 = Random.Range(0, mediumSpawnPoints.Length);
        int select15 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select15], mediumSpawnPoints[spawn15].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);

    }

    //wave 5
    IEnumerator Enemyspawner5()
    {
        shopMenu.SetActive(false);
        Cursor.visible = false;
        followMouse.crosshair.SetActive(true);
        roundStarted = true;
        int spawn = Random.Range(0, mediumSpawnPoints.Length); //sets random spawn point
        int select = Random.Range(0, mediumEnemy.Length);      //selects ice or fire enemy
        GameObject.Instantiate(mediumEnemy[select], mediumSpawnPoints[spawn].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);

        int spawn2 = Random.Range(0, mediumSpawnPoints.Length);
        int select2 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select2], mediumSpawnPoints[spawn2].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);

        int spawnF0 = Random.Range(0, flyingSpawnPoints.Length);
        int selectF0 = Random.Range(0, flyingEnemy.Length);
        GameObject.Instantiate(flyingEnemy[selectF0], flyingSpawnPoints[spawnF0].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);

        int spawnF = Random.Range(0, flyingSpawnPoints.Length);
        int selectF = Random.Range(0, flyingEnemy.Length);
        GameObject.Instantiate(flyingEnemy[selectF], flyingSpawnPoints[spawnF].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        int spawn3 = Random.Range(0, mediumSpawnPoints.Length);
        int select3 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select3], mediumSpawnPoints[spawn3].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);

        int select10 = Random.Range(0, littleEnemy.Length);
        GameObject.Instantiate(littleEnemy[select10], littleSpawnPoint.transform.position, Quaternion.identity);  //Spawnaa pieni vihollinen

        int spawn4 = Random.Range(0, mediumSpawnPoints.Length);
        int select4 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select4], mediumSpawnPoints[spawn4].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        GameObject.Instantiate(mediumEnemy[select], mediumSpawnPoints[spawn].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        GameObject.Instantiate(mediumEnemy[select3], mediumSpawnPoints[spawn3].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        int spawnF2 = Random.Range(0, flyingSpawnPoints.Length);
        int selectF2 = Random.Range(0, flyingEnemy.Length);
        GameObject.Instantiate(flyingEnemy[selectF2], flyingSpawnPoints[spawnF2].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);

        int spawnF3 = Random.Range(0, flyingSpawnPoints.Length);
        int selectF3 = Random.Range(0, flyingEnemy.Length);
        GameObject.Instantiate(flyingEnemy[selectF3], flyingSpawnPoints[spawnF3].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);

        GameObject.Instantiate(mediumEnemy[select2], mediumSpawnPoints[spawn2].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        GameObject.Instantiate(mediumEnemy[select4], mediumSpawnPoints[spawn4].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(3);

        int select8 = Random.Range(0, littleEnemy.Length);
        GameObject.Instantiate(littleEnemy[select8], littleSpawnPoint.transform.position, Quaternion.identity);  //Spawnaa pieni vihollinen

        int spawn5 = Random.Range(0, mediumSpawnPoints.Length);
        int select5 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select5], mediumSpawnPoints[spawn5].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        GameObject.Instantiate(mediumEnemy[select3], mediumSpawnPoints[spawn3].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        int spawn6 = Random.Range(0, mediumSpawnPoints.Length);
        int select6 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select6], mediumSpawnPoints[spawn6].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        GameObject.Instantiate(mediumEnemy[select2], mediumSpawnPoints[spawn2].transform.position, Quaternion.identity);

        GameObject.Instantiate(mediumEnemy[select], mediumSpawnPoints[spawn].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        int select9 = Random.Range(0, littleEnemy.Length);
        GameObject.Instantiate(littleEnemy[select9], littleSpawnPoint.transform.position, Quaternion.identity);

        int spawn11 = Random.Range(0, mediumSpawnPoints.Length);
        int select11 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select11], mediumSpawnPoints[spawn11].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);

        int spawnF4 = Random.Range(0, flyingSpawnPoints.Length);
        int selectF4 = Random.Range(0, flyingEnemy.Length);
        GameObject.Instantiate(flyingEnemy[selectF4], flyingSpawnPoints[spawnF4].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);

        int spawn12 = Random.Range(0, mediumSpawnPoints.Length);
        int select12 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select12], mediumSpawnPoints[spawn12].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);


        GameObject.Instantiate(mediumEnemy[select3], mediumSpawnPoints[spawn3].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        GameObject.Instantiate(mediumEnemy[select3], mediumSpawnPoints[spawn3].transform.position, Quaternion.identity);

        int spawn13 = Random.Range(0, mediumSpawnPoints.Length);
        int select13 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select13], mediumSpawnPoints[spawn13].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);


        int select14 = Random.Range(0, littleEnemy.Length);
        GameObject.Instantiate(littleEnemy[select14], littleSpawnPoint.transform.position, Quaternion.identity);

        GameObject.Instantiate(mediumEnemy[select], mediumSpawnPoints[spawn].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        GameObject.Instantiate(mediumEnemy[select3], mediumSpawnPoints[spawn3].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);

        GameObject.Instantiate(mediumEnemy[select6], mediumSpawnPoints[spawn6].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        int spawnF5 = Random.Range(0, flyingSpawnPoints.Length);
        int selectF5 = Random.Range(0, flyingEnemy.Length);
        GameObject.Instantiate(flyingEnemy[selectF5], flyingSpawnPoints[spawnF5].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);

        int spawn15 = Random.Range(0, mediumSpawnPoints.Length);
        int select15 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select15], mediumSpawnPoints[spawn15].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);

        int spawn16 = Random.Range(0, mediumSpawnPoints.Length);
        int select16 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select16], mediumSpawnPoints[spawn16].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        GameObject.Instantiate(mediumEnemy[select2], mediumSpawnPoints[spawn2].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);

        GameObject.Instantiate(mediumEnemy[select8], mediumSpawnPoints[spawn3].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        int select17 = Random.Range(0, littleEnemy.Length);
        GameObject.Instantiate(littleEnemy[select17], littleSpawnPoint.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(4);

        GameObject.Instantiate(mediumEnemy[select12], mediumSpawnPoints[spawn12].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);


        GameObject.Instantiate(mediumEnemy[select3], mediumSpawnPoints[spawn3].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);

        GameObject.Instantiate(mediumEnemy[select2], mediumSpawnPoints[spawn2].transform.position, Quaternion.identity);
    }
    #endregion
    IEnumerator Boss()
    {
        mainTheme.Pause();
        bossTheme.Play();
        pauseMenu.pause = true;
        enableBossText = false;
        bossText.text = "BOSS INCOMING";
        yield return new WaitForSeconds(1);
        countText.text = "3";
        yield return new WaitForSeconds(1);
        countText.text = "2";
        yield return new WaitForSeconds(1);
        countText.text = "1";
        yield return new WaitForSeconds(1);
        countText.text = "0";
        yield return new WaitForSeconds(1);
        bossText.text = "";
        countText.text = "";
        enemiesKilled = 0;
        GameObject.Instantiate(bossEnemy, bossSpawnPoint.transform.position, Quaternion.identity);
        pauseMenu.pause = false;
    }

}
