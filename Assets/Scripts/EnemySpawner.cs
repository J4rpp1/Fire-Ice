using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] mediumSpawnPoints;
    public int selected;
    public GameObject[] mediumEnemy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Enemyspawner1());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Enemyspawner1()
    {
        int spawn = Random.Range(0, mediumSpawnPoints.Length); //sets random spawn point
        int select = Random.Range(0, mediumEnemy.Length);      //selects ice or fire enemy
        GameObject.Instantiate(mediumEnemy[select], mediumSpawnPoints[spawn].transform.position, Quaternion.identity);
        Debug.Log("ensimmäinen");
        yield return new WaitForSeconds(2);
       
        int spawn2 = Random.Range(0, mediumSpawnPoints.Length);
        int select2 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select2], mediumSpawnPoints[spawn2].transform.position, Quaternion.identity);
        Debug.Log("toinen");
        yield return new WaitForSeconds(2);

        int spawn3 = Random.Range(0, mediumSpawnPoints.Length);
        int select3 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select3], mediumSpawnPoints[spawn3].transform.position, Quaternion.identity);
        Debug.Log("kolomas");
        yield return new WaitForSeconds(2);

        int spawn4 = Random.Range(0, mediumSpawnPoints.Length);
        int select4 = Random.Range(0, mediumEnemy.Length);
        GameObject.Instantiate(mediumEnemy[select4], mediumSpawnPoints[spawn4].transform.position, Quaternion.identity);
        Debug.Log("neljäs");
        yield return new WaitForSeconds(2);

        GameObject.Instantiate(mediumEnemy[select], mediumSpawnPoints[spawn].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        GameObject.Instantiate(mediumEnemy[select3], mediumSpawnPoints[spawn3].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        GameObject.Instantiate(mediumEnemy[select2], mediumSpawnPoints[spawn2].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);

        GameObject.Instantiate(mediumEnemy[select4], mediumSpawnPoints[spawn4].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);


    }
}
