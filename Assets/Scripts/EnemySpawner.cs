using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] mediumSpawnPoints;
    public int selected;
    public GameObject mediumEnemy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Enemyspawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Enemyspawner()
    {
        int spawn = Random.Range(0, mediumSpawnPoints.Length);
        GameObject.Instantiate(mediumEnemy, mediumSpawnPoints[spawn].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);
        int spawn2 = Random.Range(0, mediumSpawnPoints.Length);
        GameObject.Instantiate(mediumEnemy, mediumSpawnPoints[spawn2].transform.position, Quaternion.identity);
    }
}
