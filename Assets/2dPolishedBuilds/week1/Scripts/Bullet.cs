using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private PlayerController pControl;
    private GUIManager gui;

    [SerializeField] private GameData gameData;
    private float bulletSpeed = 15;
    
    // Start is called before the first frame update
    void Start()
    {
        gameData = FindObjectOfType<GameData>();
        gameObject.transform.SetParent(null, true);
    }

    // Update is called once per frame
    void Update()
    {
        
        StartCoroutine(DestroySelf());
        gameObject.transform.Translate(0,(bulletSpeed * Time.deltaTime) ,0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            gameData.playerScore++;
            Destroy(gameObject);
            Destroy(collision.gameObject);
            
        }
        if(collision.CompareTag("Wall"))
            Destroy(gameObject);
    }

    private IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
    
}
