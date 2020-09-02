using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemiga : MonoBehaviour
{
    public static float speed = 3;
    public Spawner mySpawner;
    private void Start()
    {
        mySpawner = GameObject.FindObjectOfType<Spawner>();
    }
    void Update()
    {
        transform.position -= transform.up * speed * Time.deltaTime;
        Invoke("Despanw", 10);

    }
    public void Despanw()
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Spawner>())
        {
            Destroy(gameObject);
            mySpawner.PlaysonidoDestruccion();
        }
        if (other.GetComponent<casa>())
        {
            Destroy(gameObject);
        }
        if (other.transform.tag == "escudo")
        {
            Destroy(gameObject);
            mySpawner.PlaySonidoEscudo();
        }
    }
}
