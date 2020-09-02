using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    public float velocity;//variable para establecer la velocidad de movimiento
    public float speed = 5f;
    
    void Update()
    {
        Movimiento();
        MovimientoMovil();
       
    }
    public void Movimiento ()
    {
      if (Spawner.ganador == true)
      {
        if (Spawner.inGame == true)
        {
          if(Input.GetKey(KeyCode.D) && transform.position.x < 7f )//se obtiene la tecla para ir hacia la derecha y se crea una condicional para moverse
          {
            transform.position += Vector3.right * velocity;//se mueve hacia la derecha si se da la condicional anterior
            transform.Rotate(0,0,speed * Time.deltaTime);
          }
          if(Input.GetKey(KeyCode.A) && transform.position.x > -7f)//se obtiene la tecla para ir hacia la izquierda y se crea una condicional para moverse
          {
            transform.position -= Vector3.right * velocity;//se mueve hacia la izquierda si se da la condicional anterior   
            transform.Rotate(0,0,-speed * Time.deltaTime);
          }  
        }
      }
    }
    public void MovimientoMovil ()
    {
        if (Spawner.ganador == true)
        {
            if (Spawner.inGame == true)
            {
                if (Input.touchCount >= 1)
                {
                    if (Input.touches[0].position.x < (Screen.width / 2) && transform.position.x > -7f)
                    {
                        transform.position -= Vector3.right * velocity;
                    }
                    if (Input.touches[0].position.x > (Screen.width / 2) && transform.position.x < 7f)
                    {
                        transform.position += Vector3.right * velocity;
                    }
                }
            }
        }
        
    }
}