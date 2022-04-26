using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceGun : MonoBehaviour
{

    public Rigidbody projectile;
    public float speed = 20;
    public float fireRate = 0.2f;
    [HideInInspector] public bool canFire;
    public Transform shootPosition;
    public Transform target;
    Animator animator;
	public AudioClip shootSoundClip;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        canFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 targetDirection = target.position - transform.position;
        float singleStep = speed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        Debug.DrawRay(transform.position, newDirection, Color.red);
        transform.rotation = Quaternion.LookRotation(newDirection);

        if (Input.GetButton("Fire2") && canFire)
        {
            animator.SetTrigger("Shoot");
            StartCoroutine(FireRate());

        }
    }   
   
 
    IEnumerator FireRate()
    {
        canFire = false;
        SFX.instance.PlayClip(shootSoundClip, 1f);
        Rigidbody instantiatedProjectile = Instantiate(projectile, shootPosition.position, shootPosition.rotation) as Rigidbody;
        instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
}
