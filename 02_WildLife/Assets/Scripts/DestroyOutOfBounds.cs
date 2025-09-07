using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    private float topBound = 40f;
    private float bottomBound = -10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((this.transform.position.z > topBound) )
        {
            Destroy(this.gameObject);
        }
      if ((this.transform.position.z < bottomBound))
        {
            Debug.Log("GAME OVER!!!!");
            Destroy(this.gameObject);
            Time.timeScale = 0;
        }
    }
}
