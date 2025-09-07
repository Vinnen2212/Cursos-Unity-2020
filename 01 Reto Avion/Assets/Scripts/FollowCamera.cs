using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FollowCamera : MonoBehaviour
{
    public GameObject followToObject;
    public Vector3 objectPosition = new Vector3();


    private void LateUpdate()
        
    {
        if (!followToObject) return;
        transform.position = followToObject.transform.TransformPoint(objectPosition);
        this.transform.LookAt(followToObject.transform);



    }
}


