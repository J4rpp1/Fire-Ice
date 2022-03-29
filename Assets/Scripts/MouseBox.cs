using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBox : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    public void Update()
    {
        //Debug.Log(mainCamera.ScreenToWorldPoint(Input.mousePosition));
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = -14f;
        transform.position = mouseWorldPosition;
        
    }

}