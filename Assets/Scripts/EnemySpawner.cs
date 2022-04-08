using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;

    MouseFollow mouseFollow;
    public TMP_Text bossText;
    public TMP_Text waveText;
    public TMP_Text countText;
    public GameObject shopMenu;
    public GameObject[] mediumSpawnPoints;
    public GameObject bossSpawnPoint;
    public GameObject littleSpawnPoint;
    public int selected;
    public GameObject[] mediumEnemy;
    public GameObject[] littleEnemy;
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
    }
    void Start()
    {
        waveText.text = "Wave 1";
        wave = 1;
        mouseFollow = FindObjectOfType<MouseFollow>();
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


        if (bossesKilled == 1)
        {
            completedWave1 = true;
            enableBossText = true;
            mouseFollow.hideCrosshair = true;
            shopMenu.SetActive(true);
            Cursor.visible = true;
            bossesKilled = 0;
        }
        if (wave == 2 && !roundStarted)
        {
            
            waveText.text = "Wave " + wave.ToString();
            StartCoroutine(Enemyspawner2());
        }
    }

    #region Wave system
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

    IEnumerator Enemyspawner2()
    {
        shopMenu.SetActive(false);
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
    #endregion
    IEnumerator Boss()
    {
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
    }

}
