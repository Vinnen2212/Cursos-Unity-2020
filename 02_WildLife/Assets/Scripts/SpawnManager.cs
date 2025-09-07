using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    private int animalIndex;

    private float spawnRangeX = 16.5f;
    private float spawnPosZ;

    [SerializeField]
    private float spawnDelay = 2.0f;
    [SerializeField]
    private float spawnIntervale = 3.0f;
   
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", spawnDelay, spawnIntervale);
        spawnPosZ = this.transform.position.z;
    }

    // Update is called once per frame
   

    private void SpawnEnemies()
    {
        float xRand = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPos = new Vector3(xRand, 0, spawnPosZ);
        animalIndex = Random.Range(0, enemies.Length);
        Instantiate(enemies[animalIndex], spawnPos, enemies[animalIndex].transform.rotation);

    }
}
