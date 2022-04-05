using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;
    public GameObject[] mediumSpawnPoints;
    public GameObject littleSpawnPoint;
    public int selected;
    public GameObject[] mediumEnemy;
    public GameObject[] littleEnemy;
    public int wave;
    public int enemiesKilled;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        StartCoroutine(Enemyspawner1());
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesKilled == 11)
        {
            Debug.Log("bossi");
        }
    }
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
        GameObject.Instantiate(littleEnemy[select7], littleSpawnPoint.transform.position, Quaternion.identity);

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
}
