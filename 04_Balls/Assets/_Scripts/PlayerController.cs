using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float moveForce;

    public GameObject focalPoint;

    public bool hasPowerUp;
    public float powerUpForce;
    public float powerUpTime;
    public GameObject[] powerUpIndicators;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
     float forwardInput = Input.GetAxis("Vertical");
        _rigidbody.AddForce(focalPoint.transform.forward * moveForce * forwardInput , ForceMode.Force);

        foreach (GameObject indicator in powerUpIndicators)
        {
            indicator.transform.position = this.transform.position + 0.3f * Vector3.down;
        }
        if (this.transform.position.y < -10)
        {
            SceneManager.LoadScene("Prototype 4");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp")) {
            hasPowerUp = true;
            Destroy(other.gameObject);
            
            StartCoroutine("PowerUpCountDown");
        }

        
    }
    private void OnCollisionEnter(Collision collision)
    { if (hasPowerUp && collision.gameObject.CompareTag("Enemy")) { 
        Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
        Vector3 awayFromPlayer = collision.gameObject.transform.position - this.transform.position;
        enemyRigidBody.AddForce(awayFromPlayer * powerUpForce, ForceMode.Impulse);
        }
    }

    IEnumerator PowerUpCountDown()
    {
        for (int i = 0; i < powerUpIndicators.Length; i++) 
        {
            powerUpIndicators[i].SetActive(true);
            yield return new WaitForSeconds(powerUpTime / powerUpIndicators.Length);
            powerUpIndicators[i].gameObject.SetActive(false);
        }
       

        hasPowerUp = false;
    }
}
