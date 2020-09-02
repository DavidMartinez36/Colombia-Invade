using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoElices : MonoBehaviour
{
    
    public float speed;

 void Update()
    {
        //transform.rotation = Quaternion.Euler(new Vector3(0,0,myRotation--));

        transform.Rotate(0,0,speed * Time.deltaTime);

    }
}
