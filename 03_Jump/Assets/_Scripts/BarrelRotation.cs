using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelRotation : MonoBehaviour
   
{
    //Variables

    public float rotationSpeed = 150;
    public float speed = 5;
    private PlayerController _playerController;



    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_playerController.GameOver)
        {
            transform.localPosition += Vector3.left * speed * Time.deltaTime;
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }
}
