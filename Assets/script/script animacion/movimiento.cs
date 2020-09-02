using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
      
    public float speed;

 void Update()
    {
      //  transform.rotation = Quaternion.Euler(new Vector3(speed++,0,0));

       transform.Rotate(speed * Time.deltaTime,0,0);

    }
}
