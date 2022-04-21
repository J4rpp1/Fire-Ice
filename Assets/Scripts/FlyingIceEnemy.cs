using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingIceEnemy : MonoBehaviour
{
    EnemySpawner enemySpawner;
    Score score;
    PlayerHp playerHp;
    public float speed = 0.4f;
    public Transform target;
    public int damage = 10;
    public float maxHp = 30;
    public float currentHp;
    public float takeDamage = 1;
    public float addPoints = 200;
    public int addToKills = 1;



    private void Awake()
    {
        playerHp = FindObjectOfType<PlayerHp>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
        score = FindObjectOfType<Score>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            //playerHp.currentHp -= Time.deltaTime * damage / 6f;
            StartCoroutine(Damage());
        }
        if (other.tag == "FireBullet")
        {
            currentHp = currentHp - takeDamage;

        }
        if (other.tag == "IceBullet")
        {
            currentHp = currentHp + takeDamage;
        }
        if (other.tag == "Bomb")
            currentHp = 0;

    }

    void Start()
    {

        target = GameObject.FindWithTag("target").transform;
        currentHp = maxHp;




    }


    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        //Debug.Log(currentHp);
        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }

        if (currentHp == 0)
        {
            enemySpawner.enemiesKilled = enemySpawner.enemiesKilled + addToKills;
            score.currentScore = score.currentScore + addPoints;
            Destroy(gameObject);
        }


    }
    IEnumerator Damage()
    {
        while (true)
        {
            //damaging = true;
            playerHp.currentHp = playerHp.currentHp - damage;
            yield return new WaitForSeconds(1);
            // damaging = false;

        }

    }
}
