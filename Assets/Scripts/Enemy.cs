using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    PlayerHp playerHp;
    public float speed = 1.0f;
    public Transform target;
    public float damage = 2;

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

    }
    void Start()
    {
        target = GameObject.FindWithTag("target").transform;
    }
   

    void Update()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
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

