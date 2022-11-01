using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    float _spawnDistance;
    float _obstacleWidth;
    float _speed = 2.5f;
    BoxCollider2D box;
    void Start()
    {
        if (gameObject.CompareTag("Ground"))
        {
            box = GetComponent<BoxCollider2D>();
            _spawnDistance = box.size.x;
        }
        else if (gameObject.CompareTag("Obstacle"))
           {
            _obstacleWidth = GameObject.FindGameObjectWithTag("Column").GetComponent<BoxCollider2D>().size.x ;
        }
       
    }

    void Update()
    {
        if (GameManager.gameOver == false)
        {
            transform.position = new Vector2(transform.position.x - _speed * Time.deltaTime, transform.position.y);
        }
        
        if (gameObject.CompareTag("Ground"))
        {
            if (transform.position.x <= -_spawnDistance)
            {

                transform.position = new Vector3(transform.position.x + 2 * _spawnDistance, transform.position.y);
            }
        }
        else if (gameObject.CompareTag("Obstacle"))
        {
            if (transform.position.x < GameManager.ButtonLeft.x - _obstacleWidth)
            {
                Destroy(gameObject);
            }
        }
    }
}
