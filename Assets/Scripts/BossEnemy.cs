using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    [SerializeField] AudioClip deathSound;
    public Animator attacAni;
    public Transform position;
    public GameObject deadEnemy;
    EnemySpawner enemySpawner;
    Score score;
    PlayerHp playerHp;
    public static BossEnemy instance;
    public float speed = 0.3f;
    public Transform target;
    public int damage = 1;
    public float maxHp = 30;
    public float currentHp;
    public float takeDamage = 1;
    public float takeBombDamage = 10;
    public float addPoints = 1000;
    public bool damaging;
    public int handsBroken;
    private bool areHandsBroken;
    public bool canTakeDamage;
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
        canTakeDamage = true;
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
            SFX.instance.PlayClip(deathSound, 1f);
            Instantiate(deadEnemy, position.position, position.rotation);
            enemySpawner.bossesKilled = enemySpawner.bossesKilled + 1;
            score.currentScore = score.currentScore + addPoints;
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
        if (other.tag == "Bomb" && areHandsBroken && canTakeDamage)
        {
            StartCoroutine(BombDamage());
        }
            
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
    IEnumerator BombDamage()
    {
        canTakeDamage = false;
        currentHp = currentHp - takeBombDamage;
        yield return new WaitForSeconds(0.9f);
        canTakeDamage = true;
    }
}
