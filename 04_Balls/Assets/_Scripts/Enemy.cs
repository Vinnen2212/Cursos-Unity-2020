using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private GameObject player;
    public float moveForce;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (player.transform.position - this.transform.position).normalized;
        _rigidbody.AddForce(direction * moveForce);

        if (this.transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
