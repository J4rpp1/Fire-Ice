using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{


    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;
    public static FollowMouse instance;
    public bool hideCrosshair;
    public GameObject crosshair;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        hideCrosshair = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;
        /*  mousePosition = Input.mousePosition;
          mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
      transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);*/

        /* if(hideCrosshair)
         {
             crosshair.SetActive(false);
         }
         if(hideCrosshair == false)
         {
             crosshair.SetActive(true);
         }*/

    }
}


