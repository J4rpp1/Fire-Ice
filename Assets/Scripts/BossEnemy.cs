using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{

    EnemySpawner enemySpawner;
    Score score;
    PlayerHp playerHp;
    public static BossEnemy instance;
    public float speed = 0.3f;
    public Transform target;
    public int damage = 1;
    public float maxHp = 30;
    public float currentHp;
    public float takeDamage = 5;
    public float addPoints = 1000;
    public int addToKills = 1;
    public bool damaging;
    public int handsBroken;
    private void Awake()
    {
        instance = this;
        playerHp = FindObjectOfType<PlayerHp>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
        score = FindObjectOfType<Score>();
    }
    void Start()
    {
        target = GameObject.FindWithTag("target").transform;
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        //Debug.Log(currentHp);
        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }
        if (handsBroken == 2)
        {
            Debug.Log("käsirauvat");
        }
        /*if (currentHp< 0)
        {
            enemySpawner.bossesKilled = enemySpawner.bossesKilled + addToKills;
            score.currentScore = score.currentScore + addPoints;
            Destroy(gameObject);
        }*/

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && !damaging)
        {
            //playerHp.currentHp -= Time.deltaTime * damage / 6f;
            StartCoroutine(Damage());
        }
        if (other.tag == "FireBullet")
        {
            currentHp = currentHp + takeDamage;
        }
        if (other.tag == "IceBullet")
        {
            currentHp = currentHp - takeDamage;
        }
        if (other.tag == "Bomb")
            currentHp = currentHp - 10;
    }

    IEnumerator Damage()
    {
        while (true)
        {
            Debug.Log("Perse");
            damaging = true;
            playerHp.currentHp = playerHp.currentHp - damage;
            yield return new WaitForSeconds(1);
            damaging = false;

        }

    }
}
