using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0f,33f), SerializeField] //Rango de la siguiente variable para el editor , Añadir al editor una variable privada
    private float speed = 20f;

    [Range(0, 90), SerializeField]
    private float turnSpeed = 10f;

    private float horizontalInput, verticalInput;















    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //Tenemos que movernos hacia delante
        this.transform.Translate(speed*Time.deltaTime*Vector3.forward * verticalInput); // Velocidad * tiempo * direccion
        transform.Rotate(turnSpeed * Time.deltaTime * Vector3.up * horizontalInput);
    }
}
