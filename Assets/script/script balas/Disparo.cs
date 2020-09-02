using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public GameObject bala1, bala2;
    GameObject myBala;
    public Spawner mySpawner;
    public static int tipoDeBala;
    private void Awake()
    {
      tipoDeBala = 0;
      mySpawner = GameObject.FindObjectOfType<Spawner>();
    }
    void Start()
    {
        StartCoroutine("SpawnDeBalas");
    }
    // corrutina para los disparos aliados
    IEnumerator SpawnDeBalas()
    {

        while (Spawner.inGame == true)
        {
            if (Spawner.ganador == true)
            {
                switch (tipoDeBala)
                {
                    case 0:
                        //bala1 hace menos daño 
                        myBala = Instantiate(bala1, transform.position, Quaternion.identity);
                        myBala.AddComponent<Bala>();
                       mySpawner.PlaySonidoBala();
                        break;
                    case 1:
                        //bala2 mata de un dispro al burro, de dos al carro y 25 al jefe
                        myBala = Instantiate(bala2, transform.position, Quaternion.identity);
                        myBala.AddComponent<BalaDos>();
                        mySpawner.PlaySonidoBala();
                        break;
                }
            }
            yield return new WaitForSeconds(Spawner.cadencia);// cadencia va disminulledo cada vez que se calociona con myAmmo

        }

    }
}
