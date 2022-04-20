using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
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
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
