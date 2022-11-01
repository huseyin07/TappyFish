using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    [SerializeField] GameObject Obstacle;
    [SerializeField] float MaxTime;
    float _timer,_RandomY;
    [SerializeField] float maxY;
    [SerializeField] float minY;
    void Start()
    {
        _RandomY = Random.Range(minY, maxY);
       // InstantiateObstacle();
    }
    void Update()
    {
        if (!GameManager.gameOver && GameManager.gameStarted)
        {
            _timer += Time.deltaTime;
            if (_timer >= MaxTime)
            {
                _RandomY = Random.Range(minY, maxY);
                InstantiateObstacle();
                _timer = 0;
            }
        }
     
    }
    public void InstantiateObstacle()
    {
        GameObject newObstacle = Instantiate(Obstacle);
        newObstacle.transform.position = new Vector2(this.transform.position.x, _RandomY);
    }
}
