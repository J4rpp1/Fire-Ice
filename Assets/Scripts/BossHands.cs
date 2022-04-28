using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHands : MonoBehaviour
{
	public ParticleSystem particles;
	[SerializeField] AudioClip hurtSound;
	[SerializeField] AudioClip blockSound;
	BossEnemy bossEnemy;
    public bool isFireHand;
	public float takeDamage;
	public float currentHp;
	public float maxHp;

    void Start()
    {
		currentHp = maxHp;
		
		bossEnemy = FindObjectOfType<BossEnemy>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (isFireHand)
		{
			if (other.tag == "FireBullet")
			{
				EnemyHurt(false);
			}
			if (other.tag == "IceBullet")
			{
				EnemyHurt(true);
			}
		}

		if (!isFireHand)
		{
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
	// Update is called once per frame
	void Update()
    {
		if (currentHp > maxHp)
		{
			currentHp = maxHp;
		}

		if (currentHp < 1)
		{
			bossEnemy.handsBroken = bossEnemy.handsBroken + 1;
			particles.Play();
			Destroy(gameObject);

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
}
