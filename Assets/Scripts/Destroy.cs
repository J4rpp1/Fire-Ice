using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float destroyIn = 1;
    void Start()
    {
        StartCoroutine(DestroyThis());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(destroyIn);
        Destroy(gameObject);
    }
}
