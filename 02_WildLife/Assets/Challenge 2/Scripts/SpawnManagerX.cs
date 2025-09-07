using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;
    private int randomRange;

    private float counter = 0.0f;
    private float nextWaitBall = 5.0f;

    // Start is called before the first frame update
    
    private void Update()
    {
        counter = counter + Time.deltaTime;

        if (counter >= nextWaitBall)
        {
            SpawnRandomBall();
            nextWaitBall = Random.Range(3f, 6f);
            counter = 0;
        }
    }
    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        randomRange = Random.Range(0, ballPrefabs.Length);
        Instantiate(ballPrefabs[randomRange], spawnPos, ballPrefabs[randomRange].transform.rotation);
    }

}
