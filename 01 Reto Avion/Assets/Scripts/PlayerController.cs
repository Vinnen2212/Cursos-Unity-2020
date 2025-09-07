using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0, 50), SerializeField]
    public float speed;
    public float turnSpeed;
    public float upSpeed;

    private float speedFoward;
    private float speedRotate;
    private float speedUp;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speedFoward = Input.GetAxis("Jump");
        transform.Translate(speed * Time.deltaTime * Vector3.forward * speedFoward);

        speedRotate = Input.GetAxis("Horizontal");
        transform.Rotate(turnSpeed * Time.deltaTime * Vector3.up * speedRotate);

        speedUp = Input.GetAxis("Vertical");
        transform.Rotate(upSpeed * Time.deltaTime * Vector3.right * speedUp);

    }
}
