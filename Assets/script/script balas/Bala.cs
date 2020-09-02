using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public static float speed = 5;
    public Spawner mySpawner;

    private void Start()
    {
        mySpawner = GameObject.FindObjectOfType<Spawner>();
    }
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        Invoke("Despanw",5);
    }
    public void Despanw ()
    {
        Destroy(gameObject);
    }  
    void OnTriggerEnter(Collider other) 
    {
        if (other.GetComponent<DonkeyBomb>())
        {
            Destroy(gameObject);
        }
        if (other.GetComponent<BombCar>())
        {
            Destroy(gameObject);
            mySpawner.PlaysonidoDestruccion();
        }
    }
}
