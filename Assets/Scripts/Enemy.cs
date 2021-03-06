using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] AudioClip hurtSound;
	[SerializeField] AudioClip blockSound;
	[SerializeField] AudioClip deathSound;

	public GameObject deadEnemy;
	public bool isFireEnemy;
	public bool isFlyingEnemy;
	public bool isSmallEnemy;
	EnemySpawner enemySpawner;
	public Transform position;
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

	Vector3 soundPosition;



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
			StartCoroutine(Damage());
			
			if (other.tag == "FireBullet")
			{
				EnemyHurt(false);
			}
			if (other.tag == "IceBullet")
			{
				EnemyHurt(true);
			}
		}

		if (!isFireEnemy)
		{	
			if (other.name == "Player" && canDamage)
			StartCoroutine(Damage());

			if (other.tag == "FireBullet")
			{
				EnemyHurt(true);
			}
			if (other.tag == "IceBullet")
			{
				EnemyHurt(false);
			}
		}

		if (other.tag == "Bomb")
			currentHp = 0;

	

	}
	/* private void OnTriggerEnter(Collider other)
	{
		if (other.name == "Player" && canDamage)
			StartCoroutine(Damage());
	} */
	void Start()
	{
		canDamage = true;
		if (isFlyingEnemy)
		{
			target = GameObject.FindWithTag("FlyingTarget").transform;
		}
		else
		{
			target = GameObject.FindWithTag("target").transform;

		}

		currentHp = maxHp;

		soundPosition = Camera.main.transform.position;


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
			EnemyDie();
		}

		if (enemySpawner.wave > 5 && !isFlyingEnemy && !isSmallEnemy)
        {
			speed = 1.3f;
		}
		if (enemySpawner.wave > 6 && !isFlyingEnemy && !isSmallEnemy)
		{
			speed = 1.4f;
		}
		if (enemySpawner.wave > 7 && !isFlyingEnemy && !isSmallEnemy)
		{
			speed = 1.5f;
		}
	}

	void EnemyHurt(bool hurt)
	{
		if (hurt)
		{
			SFX.instance.PlayClip(hurtSound, 1f);
			currentHp = currentHp - takeDamage;
		}
		else
		{
			SFX.instance.PlayClip(blockSound, 1f);
			currentHp = currentHp + takeDamage;
		}
	}

	void EnemyDie()
	{
		enemySpawner.enemiesKilled = enemySpawner.enemiesKilled + addToKills;
		score.currentScore = score.currentScore + addPoints;
		SFX.instance.PlayClip(deathSound, 1f);
		Instantiate(deadEnemy, position.position, position.rotation);
		Destroy(gameObject);
	}
	IEnumerator Damage()
	{
		enemySpawner.enemiesKilled = enemySpawner.enemiesKilled + addToKills;
		playerHp.hurtSound.Play();
		canDamage = false;
		playerHp.currentHp = playerHp.currentHp - damage;
		yield return new WaitForSeconds(0.1f);
		Instantiate(deadEnemy, position.position, position.rotation);

		Destroy(gameObject);

	}
}
