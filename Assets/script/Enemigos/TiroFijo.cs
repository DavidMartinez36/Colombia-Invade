using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroFijo : Enemy
{
    public Spawner mySpawner;
    public static  float LifeTiroFijo;
    public float velocity = 0.5f;
    public float vel = 1;
    private void Awake()
    {
        LifeTiroFijo = pointLife;
    }
    void Start()
    {
       mySpawner = GameObject.FindObjectOfType<Spawner>();
       pointLife = 500f;
       StartCoroutine("SpawnDeBalas");
       StartCoroutine("Moving");

    }
    void Update()
    {
        LifeTiroFijo = pointLife;
        if (transform.position.y >= 6f)
        {
            transform.position -= transform.up * vel * Time.deltaTime;

        }

    }
    void OnTriggerEnter(Collider other) 
    {

         if (other.GetComponent<Bala>())
         {
            pointLife = pointLife - 10;
        
         }
        if (other.GetComponent<BalaDos>())
        {
            pointLife = pointLife - 25;
        }

        if (pointLife <= 0)
        {
            mySpawner.PlaySonidoMuerteJefe();
            FindObjectOfType<Spawner>().Win();
            Destroy(gameObject);
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
                mySpawner.PlaySonidoDisparaJefe();
            }
         yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator Moving()
    {
        while (Spawner.inGame == true)
        {
            if (Spawner.ganador == true)
            {
                int rnd = Random.Range(0,2);
          
         
                if (rnd == 0 && transform.position.x < 7f)
                {
                transform.position += Vector3.right * velocity;
                }
                else if (rnd == 1 && transform.position.x > -7f)
                {
                transform.position -= Vector3.right * velocity;
                }
            }
         yield return new WaitForSeconds(1);
        }
      
    }
}
