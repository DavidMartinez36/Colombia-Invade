using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CadenciaDeDisparo : MonoBehaviour
{
    public float speed = 4;

    void Update()
    {
        transform.position -= transform.forward * speed * Time.deltaTime;
        Invoke("destruir", 10);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Spawner>())
        {
            Destroy(gameObject);
            if (Spawner.cadencia >= 0.32f)
            Spawner.cadencia = Spawner.cadencia - 0.01f;
           // Debug.Log(Spawner.cadencia);
        }
    }
    public void destruir()
    {
        Destroy(gameObject);
    }
}
