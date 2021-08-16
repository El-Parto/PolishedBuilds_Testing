using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using Random = UnityEngine.Random;
public class Enemy : MonoBehaviour
{
    [SerializeField] private GUIManager gooey;
    [SerializeField] private GameData data;
    //[SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private float verticalSpeed;

    [SerializeField] private float horizontalSpeed;
    public float visibleScore;
    
    // Start is called before the first frame update
    void Start()
    {
        gooey = FindObjectOfType<GUIManager>();
        data = FindObjectOfType<GameData>();
        
        verticalSpeed = Random.Range(data.minSpeedY, data.maxSpeedY); 
        //horizontalSpeed = Random.Range(0, -3.5f);
        horizontalSpeed = 0;
        gameObject.transform.SetParent(null);
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate((horizontalSpeed *Time.deltaTime),(verticalSpeed *Time.deltaTime),0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            //data.playerScore++;
            Debug.Log("enemydown!");
            Destroy(gameObject);
        }
        if (collision.CompareTag("Player"))
        {
            data.lives--;
            Destroy(gameObject);
        }
    }


    public void Falling()
    {
           
        float x = -1 * Time.deltaTime;
        float y = -1 * Time.deltaTime;
        
    }

    private void OnDestroy()
    {
        //gooey.score++;
        
        //visibleScore++;
        data.minSpeedY -= 0.05f;
        data.maxSpeedY -= 0.1f;
    }
}
