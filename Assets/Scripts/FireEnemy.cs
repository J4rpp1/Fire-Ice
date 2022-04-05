using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemy : MonoBehaviour
{
    PlayerHp playerHp;
    public float speed = 1.0f;
    public Transform target;
    public float damage = 2;
    public float maxHp = 10;
    public float currentHp;
    public float takeDamage = 1;
   



    private void Awake()
    {
        playerHp = FindObjectOfType<PlayerHp>();
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
            currentHp = currentHp + takeDamage;
        }
        if (other.tag == "IceBullet")
        {
            currentHp = currentHp - takeDamage;
        }

    }
  
    void Start()
    {
        target = GameObject.FindWithTag("target").transform;
        currentHp = maxHp;

       

        
    }


    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
       // Debug.Log(currentHp);
        if (currentHp > 10)
        {
            currentHp = maxHp;
        }

        if (currentHp == 0)
        {
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
            Debug.Log("Loppu");
        }

    }
}
