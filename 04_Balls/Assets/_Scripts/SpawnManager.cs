using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    private float spawnRange = 9;
    public GameObject enemyPrefab;
    private int enemyCount;
    private int enemyWave = 0;
    public GameObject powerUpSpawn;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(enemyWave);
       
    }

    // Update is called once per frame
    void Update()
    {

        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount == 0)
        {
            enemyWave++;
            SpawnEnemyWave(enemyWave);
            Instantiate(powerUpSpawn, GenerateSpawnPos(), powerUpSpawn.transform.rotation);
        }

       
    }
    /// <summary>
    /// Genera una posicion aleatoria dentro de la zona de juego
    /// </summary>
    /// <returns>Devuelve una posicion aleatoria dentro de la zona de juego.</returns>
    private Vector3 GenerateSpawnPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
    /// <summary>
    /// Metodo que genera un numero determinado de enemigos en pantalla. 
    /// </summary>
     public void SpawnEnemyWave(int enemySpawn)

    {
      
        for (int i = 0; i < enemySpawn; i ++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
        }

    }
}
