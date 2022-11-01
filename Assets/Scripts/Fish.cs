using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField]
    float _speed=8f,angle,MaxAngle,MinAngle;
    [SerializeField] Score score;
    [SerializeField] GameManager gameManager;
    [SerializeField] Sprite FishDied;
    [SerializeField] ObstacleSpawn obstacleSpawn;
    [SerializeField] AudioSource swim,hit,point;
    Rigidbody2D rg;
    bool TouchedGrounded;
    SpriteRenderer sp;
    Animator anim;
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        rg.gravityScale = 0;
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        Swim();
    }
    private void FixedUpdate()
    {
        FishRotation();
    }
    void Swim()
    {
        if (Input.GetMouseButtonDown(0) && !GameManager.gameOver)
        {
            if (GameManager.gameStarted == false)
            {
                swim.Play();
                rg.gravityScale = 4f;
                rg.velocity = Vector2.zero;
                rg.velocity = new Vector2(rg.velocity.x, _speed);
                obstacleSpawn.InstantiateObstacle();
                gameManager.GameHasStarted();
            }
            else
            {
                swim.Play();
                rg.velocity = Vector3.zero;
                rg.velocity = new Vector2(rg.velocity.x, _speed);
            }
        }
    }
    void FishRotation()
    {
        if(rg.velocity.y> 0)
        {
            if(angle <= MaxAngle)
            {
                angle = angle + 4;
            }
        }
        else if (rg.velocity.y < 0)
        {
            if(angle > MinAngle)
            {
                angle = angle - 2;
            }
        }
        if (!TouchedGrounded)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            point.Play();
            score.Scored();
        }
        else if (collision.CompareTag("Column") && !GameManager.gameOver)
        {
            FishFailEfect();
            gameManager.GameOver();
            GameOver();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            
            if (!GameManager.gameOver)
            {
                FishFailEfect();
                gameManager.GameOver();
                GameOver();
            }
            else
            {
                gameManager.GameOver();
                GameOver();
            }
        }
    }
    void GameOver()
    {
        TouchedGrounded = true;
        transform.rotation = Quaternion.Euler(0, 0, -90);
        sp.sprite = FishDied;
        anim.enabled = false;

    }
    void FishFailEfect()
    {
        hit.Play();
    }
}
