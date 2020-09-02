using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonkeyBomb : Enemy
{
    public GameObject explocionBurro;
    public Spawner mySpawner;
    float velocity = 0.5f;
    private void Awake()
    {
        mySpawner = GameObject.FindObjectOfType<Spawner>();
    }
    void Start()
    {
        StartCoroutine("SpawnDeBalas");
        StartCoroutine("Moving");
    }
    void Update()
    {
       if (pointLife <= 0)
        {
            GameObject myExplocion;
            myExplocion = Instantiate(explocionBurro,transform.position,Quaternion.identity);
            Destroy(gameObject);

            mySpawner.PlaySonidoMurteBurro();
            mySpawner.myPuntos = 1; 
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
               
            }
            yield return new WaitForSeconds(4);
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
                            transform.position += Vector3.right * velocity;
                        break;
                    case 1:
                        if (transform.position.x > -7f)
                            transform.position -= Vector3.right * velocity;
                        break;
                }
            }
            yield return new WaitForSeconds(1);
        }

    }
    void OnTriggerEnter(Collider other) 
    {

         if (other.GetComponent<Bala>())
         {
            mySpawner.PlaySonidoBurro();
            pointLife = pointLife - 20;
            int rnd = Random.Range(0,100);
            if (rnd >= 50)
            {
                speedIncrease = true;
            }
            if (rnd <= 10)
            {
                ammoTwo = true;
            }
         }
        if (other.GetComponent<BalaDos>())
        {
            mySpawner.PlaySonidoBurro();
            pointLife = pointLife - 100;
            int rnd = Random.Range(0, 100);
            if (rnd <= 10)
            {
                speedIncrease = true;
            }
        }
    }
}
