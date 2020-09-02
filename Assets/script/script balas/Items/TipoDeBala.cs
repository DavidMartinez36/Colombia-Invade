using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipoDeBala : MonoBehaviour
{
    public float speed = 4;

    void Update()
    {
        transform.position -= transform.forward * speed * Time.deltaTime;
        Invoke("destruir",20);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Spawner>())
        {
            Destroy(gameObject);
             Disparo.tipoDeBala = 1;

            Debug.Log(Disparo.tipoDeBala);
        }
    }
    public void destruir ()
    {
     Destroy(gameObject);
    }
}
