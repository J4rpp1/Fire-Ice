using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BombAttack : MonoBehaviour
{
    EnemySpawner enemySpawner;
    PauseMenu pauseMenu;
    public int bombCount;
    public float speed;
    public Rigidbody projectile;
    public Transform shootPosition;
    public TMP_Text bombText;
    
    void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        pauseMenu = FindObjectOfType<PauseMenu>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && bombCount > 0 && !pauseMenu.pause)
        {
            Rigidbody instantiatedProjectile = Instantiate(projectile, shootPosition.position, shootPosition.rotation) as Rigidbody;
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
            bombCount = bombCount - 1;
        }

        bombText.text = "" + bombCount.ToString();
    }
}
