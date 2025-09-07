using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
            {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}
