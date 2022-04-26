using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
	[SerializeField] AudioClip bombClip;
    public GameObject explosion;
    public Transform position;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Explode());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(0.7f);
		AudioSource.PlayClipAtPoint(bombClip, Camera.main.transform.position);
        Instantiate(explosion, position.position, position.rotation);
        Destroy(gameObject);
    }
}
