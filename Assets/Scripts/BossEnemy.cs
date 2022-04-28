using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public Animator attacAni;
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
    public bool damaging;
    public int handsBroken;
    private bool areHandsBroken;
    private void Awake()
    {
        attacAni = GetComponentInChildren<Animator>();
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
            areHandsBroken = true;
            speed = 0.5f;
            
        }
        if (currentHp < 1)
        {
            
            /* enemySpawner.bossesKilled = enemySpawner.bossesKilled + 1;
            score.currentScore = score.currentScore + addPoints;*/
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && !damaging)
        {
            //playerHp.currentHp -= Time.deltaTime * damage / 6f;
            StartCoroutine(Damage());
        }
        if (other.tag == "FireBullet" && areHandsBroken)
        {
            currentHp = currentHp - takeDamage;
        }
        if (other.tag == "IceBullet" && areHandsBroken)
        {
            currentHp = currentHp - takeDamage;
        }
        if (other.tag == "Bomb" && areHandsBroken)
            currentHp = currentHp - 10;
    }

    IEnumerator Damage()
    {
        while (true)
        {
            damaging = true;
            attacAni.SetBool("IsAttacking", true);
            
            yield return new WaitForSeconds(1.57f);
            playerHp.currentHp = playerHp.currentHp - damage;
            damaging = false;

        }

    }
}
