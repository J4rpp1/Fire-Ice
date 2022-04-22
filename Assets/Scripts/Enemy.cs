using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool isFireEnemy;
    public bool isFlyingEnemy;
    EnemySpawner enemySpawner;
    Score score;
    PlayerHp playerHp;
    public float speed = 0.7f;
    public Transform target;
    public int damage = 2;
    public float maxHp = 5;
    public float currentHp;
    public float takeDamage = 1;
    public float addPoints = 100;
    public int addToKills = 1;
    private bool canDamage;



    private void Awake()
    {
        playerHp = FindObjectOfType<PlayerHp>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
        score = FindObjectOfType<Score>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (isFireEnemy)
        {
            if (other.name == "Player" && canDamage)
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
        }

        if (!isFireEnemy)
        {
            if (other.name == "Player" && canDamage)
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
        }

        if (other.tag == "Bomb")
            currentHp = 0;

    }

    void Start()
    {
        canDamage = true;
        if(isFlyingEnemy)
        {
            target = GameObject.FindWithTag("FlyingTarget").transform;
        }
        else
        {
            target = GameObject.FindWithTag("target").transform;
           
        }
        
        currentHp = maxHp;




    }


    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        // Debug.Log(currentHp);
        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }

        if (currentHp == 0 && canDamage)
        {
            enemySpawner.enemiesKilled = enemySpawner.enemiesKilled + addToKills;
            score.currentScore = score.currentScore + addPoints;
            Destroy(gameObject);

        }


    }


    IEnumerator Damage()
    {
        enemySpawner.enemiesKilled = enemySpawner.enemiesKilled + addToKills;
        playerHp.hurtSound.Play();
        canDamage = false;
        playerHp.currentHp = playerHp.currentHp - damage;
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);

    }
}
