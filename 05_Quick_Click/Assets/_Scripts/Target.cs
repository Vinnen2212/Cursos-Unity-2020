using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{

    private Rigidbody _rigidbody;
    float xSpawnPosition = 4.3f;
    float ySpawnPosition = -5f;
    float minImpulse = 12f;
    float maxImpulse = 16.5f;
    float torque = 15;
  
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        RandomImpulseUp();
        RandomTorque();
        RandomSpawnPosition();
    }

   /// <summary>
   /// Da un impulso al rigidbody hacia arriba aleatorio entre el minImpulse y el maxImpulse
   /// </summary>
    void RandomImpulseUp()
    {
        _rigidbody.AddForce(Vector3.up * Random.Range(minImpulse, maxImpulse), ForceMode.Impulse);
     
    }

    /// <summary>
    /// Añade un torque al rigidbody aleatorio entre -torque y torque
    /// </summary>
    void RandomTorque()
    {
        _rigidbody.AddTorque(Random.Range(-torque, torque), Random.Range(-torque, torque), Random.Range(-torque, torque));
    }

    /// <summary>
    /// Da una posicion aleatoria en el eje x entre el rango fijado y una posicion fija en el eje y
    /// </summary>
    void RandomSpawnPosition()
    {
        _rigidbody.transform.position = new Vector3(Random.Range(-xSpawnPosition, xSpawnPosition), ySpawnPosition, 0);
    }
    
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillZone"))
        {
            Destroy(gameObject);
        }
    }
}
