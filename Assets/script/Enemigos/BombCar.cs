using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BombCar : Enemy
{
    public Spawner mySpawner;
    public float velocity = 0.5f;
    int explocion = 0;
    public GameObject  explocionCarro;

    private void Awake()
    {
        mySpawner = GameObject.FindObjectOfType<Spawner>();

    }
    private void Start()
    {
        StartCoroutine("SpawnDeBalas");
        StartCoroutine("Moving");

    }
    void Update()
    {
        if (pointLife <= 0)
        {
            GameObject myExplocion;
            Destroy(gameObject);
            myExplocion = Instantiate(explocionCarro,transform.position,Quaternion.identity);
            mySpawner.PlaySonidoBom();
            mySpawner.myPuntos = 1;
        }
        if (explocion >= 4)
        {
            transform.position -= transform.right * velocity * Time.deltaTime;
        }

    }
    IEnumerator SpawnDeBalas()
    {
        while (Spawner.inGame == true)
        {
            if (Spawner.ganador == true)
            {
                GameObject Bala = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                Bala.transform.localScale = new Vector3(0.21422f, 0.21422f, 0.21422f);
                Bala.transform.position = transform.position;
                Bala.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                Bala.AddComponent<BalaEnemiga>();
                Bala.AddComponent<SphereCollider>();
                Bala.GetComponent<SphereCollider>().isTrigger = true;
                mySpawner.PlaySonidoDiparoEnemigo();

            }
            yield return new WaitForSeconds(5);
        }
    }
    IEnumerator Moving()
    {
        while (Spawner.inGame == true)
        {
            if (Spawner.ganador == true)
            {
                int rnd = Random.Range(0, 2);
                switch (rnd)
                {
                    case 0:
                        if (transform.position.x < 7f)
                        {
                            transform.position += Vector3.right * velocity;
                            transform.Rotate(0, 0, velocity * Time.deltaTime);
                        }
                            explocion = explocion + 1;
                        break;
                    case 1:
                        if (transform.position.x > -7f)
                        {
                            transform.position -= Vector3.right * velocity;
                            transform.Rotate(0,0,-velocity*Time.deltaTime);
                        }
                        explocion = explocion + 1;
                        break;
                }
            }
            yield return new WaitForSeconds(4);
        }

    }
    void OnTriggerEnter(Collider other) 
    {

        if (other.GetComponent<Bala>())
        {
            pointLife = pointLife - 10;
            int rnd = Random.Range(0,100);
            if (rnd >= 50)
            {
                speedIncrease = true;
            }
            if (rnd <= 50)
            {
                ammoTwo = true;
            }
        }
        if (other.GetComponent<BalaDos>())
        {
            pointLife = pointLife - 50;
            int rnd = Random.Range(0, 100);
            if (rnd <= 10)
            {
                speedIncrease = true;
            }
        }
        if (other.GetComponent<casa>() || other.GetComponent<Spawner>())
        {
            pointLife = pointLife - 100;
        }
        if (other.transform.tag == "despwan")
        {
            Destroy(gameObject);
            GameObject myExplocion;
            myExplocion = Instantiate(explocionCarro, transform.position, Quaternion.identity);

        }
    }
}
