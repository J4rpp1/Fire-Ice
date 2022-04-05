using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Destroy");
    }
    private void OnCollisionEnter(Collision collision)
    {
       // Debug.Log("osui");
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(6);
        Destroy(gameObject);
    }
}
