using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class casa : MonoBehaviour
{
    public AudioClip explocion;
    public GameObject explocionCasa;

   public  float vida = 100;
    public static bool casaDestruida = true;
    void Update()
    {
        if (vida <= 0 && casaDestruida == true)
        {
            casaDestruida = false;
            GameObject myExplocion;
            myExplocion = Instantiate(explocionCasa,transform.position,Quaternion.identity);
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(explocion, Camera.main.transform.position);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BalaEnemiga>())
        {
            vida = vida - 10;
        }
        if(other.GetComponent<BombCar>())
        {
            vida = vida - 50;

        }
    }
}
