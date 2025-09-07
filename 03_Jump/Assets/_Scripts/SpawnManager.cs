using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Variables    
    private Vector3 posX;
    public GameObject[] obstacles;
    public float waitTime = 2;
    public float timeDelay = 2;
    private PlayerController _playerController;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        posX = this.transform.position;
        InvokeRepeating("SpawnObstacles", waitTime, timeDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacles()
    {
        if (!_playerController.GameOver)
        {
            GameObject obstacle = obstacles[Random.Range(0, obstacles.Length)];
            Instantiate(obstacle, posX, obstacle.transform.rotation);
        }
        
    }
}
