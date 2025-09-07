using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Threading;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    float counter = 2f;
    float waitTime = 1f;
    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        counter = counter + Time.deltaTime;
       
        if (counter >= waitTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                counter = 0;
            }
        }
    }
}
