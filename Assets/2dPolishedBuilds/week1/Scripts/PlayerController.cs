using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; //your bullet
    [SerializeField] private Transform playerPos; //the position of the instantiated bullet 
    [SerializeField] private Rigidbody2D playerRB; //player's rigid body

    [SerializeField] private float moveSpeed = 20; //player's movespeed
    [SerializeField] private float moving;// a variable for move speed to affect.

    [SerializeField] private GameData pData;
    
    [SerializeField] private GameObject enemySpawner; //not enemy spawner, just the game object that holds everything.
    [SerializeField] private GameObject lose;
    public bool testLose = false;

    
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        pData = FindObjectOfType<GameData>();
        //enemySpawner = FindObjectOfType<EnemySpawner>().gameObject; // finds whatever has the Enemy spawner script that is attached to a game object
        // since there's only one enemy spawner, this way should be fine.
    }

    // Update is called once per frame
    void Update()
    {
        playerRB.velocity = new Vector2(moving, 0);

        Move();
        Fire(bulletPrefab);
        Death();
    }
    
    /// <summary>
    /// moves left and right based on move speed and input manager's "horizontal" keycodes.
    /// </summary>
    public void Move()
    {

        moving = Input.GetAxisRaw("Horizontal") * moveSpeed;
        
    }
    
    /// <summary>
    /// Instantiates a "bullet" gameobject after pressing down spacebar.
    /// </summary>
    public void Fire(GameObject _bullet)
    {
        _bullet = bulletPrefab;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_bullet, playerPos);
            
        }
        
    }

    public void Death()
    {
        if (pData.lives == 0)
        {
            testLose = true;
            Destroy(gameObject);
            lose.SetActive(true);
            enemySpawner.SetActive(false);
        }
            
        
    }
}
