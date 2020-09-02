using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Spawner : MonoBehaviour
{
    public GameObject enemyOne, enemyTow, jefeFinal, bala1, bala2, speedObject, ammo;
    public TextMeshProUGUI gameOver;
    public TextMeshProUGUI vida;
    public TextMeshProUGUI Winner;
    public TextMeshProUGUI numeroDecasa;
    public float tiempoSpawn;
    public float PuntoDeVida;
    public int numeroDeVidas;
    public int myCasas;
    public int myPuntos = 0;
    public TextMeshProUGUI puntos;
    public TextMeshProUGUI vidaJefe;
    GameObject myBala;
    public static float cadencia;

    public static bool inGame = true;
    public static bool ganador = true;
    public static bool inmortal = true;
    bool temporal = true;
    public float contraReloj; //tiempo 
    public TextMeshProUGUI contador;
    public float velocidad = 1f; // velocidad del tiempo

    bool tiempofuera = true;
    bool spanwJefe = true;
    bool jefeFinalVivo = false;

    public AudioClip audioBala;
    public AudioClip audioDestruccion;
    public AudioClip audioDisparoEnemigo;
    public AudioClip audioDisparoJefe;
    public AudioClip audioBom,audioBurro,audioMuerteBurro,audioEscudo,audioMuerteJefe,audioGameOver;
    private void Awake()
    {
        // inicializacion de variables static
        inGame = true;
        ganador = true;
        inmortal = true;
        cadencia = 1f;
    }
    void Start()
    {
        tiempoSpawn = 6;
        myCasas = 6;
        PuntoDeVida = 100;
        numeroDeVidas = 3; 
        cadencia = 1f;
        //inizializcion de corutinas para es spawneo de enemigo
        StartCoroutine("Spawns");
      
    }
    void Update()
    {
        /* informacion para retroalimentar a el jugador. Vida,Tiempo...  */
        contador.text = "" + contraReloj.ToString("f0");
        puntos.text = ""+ myPuntos;
        vida.text = ""+PuntoDeVida.ToString("f0");
        numeroDecasa.text = "" + myCasas;
        TiempoDeSpawn();// ingremento del spawn enemigo 
        Lose(); // condiciones de derrota 

        if (jefeFinalVivo == true)
        {
          vidaJefe.text = "Tiro Fijo Life  " + TiroFijo.LifeTiroFijo.ToString("f0");

        }

        if (tiempofuera == true )
        {
         contraReloj += Time.deltaTime; // cronometro
        }

        if (Enemy.speedIncrease == true)
        {
         VelocidadDeDisparo(); // item de velocidad 
         Enemy.speedIncrease = false;
        }

        if (Enemy.ammoTwo == true)
        {
         bullets();// item que cambi de disparo 
         Enemy.ammoTwo = false;
        }
       
        if (inGame == true && (int) contraReloj == 180f && spanwJefe == true) // condicion para spawnear el jefe
        {
         SpawnsJefeFinal(); // funcion de spawn del jefe 
         spanwJefe = false;
         jefeFinalVivo = true;
        }
       
      
    }
    // genera el jefe final 
    void SpawnsJefeFinal()
    {
        GameObject enemy;
        enemy = Instantiate(jefeFinal, new Vector3(0, 0, 0), Quaternion.Euler(0, 180, 0));
        enemy.transform.position = new Vector3(0,11,5);
        enemy.AddComponent<TiroFijo>(); 
    }
    // corrutina para spawn de enemigos
    IEnumerator Spawns()
    {
        /* while true 
           int rnd dicta cual enemogo spawnea
         */
        while (inGame == true)
        {
            if (ganador == true)
            {
                int rnd = Random.Range(0, 2);
                GameObject enemy;
                switch (rnd)
                {
                    case 0:
                        // enemyOne BurroBomba
                        enemy = Instantiate(enemyOne, new Vector3(0, 0, 0), Quaternion.Euler(-180,-120f, 90));
                        enemy.transform.position = new Vector3(Random.Range(-7, 7), Random.Range(4f, 7), 5.5f);
           
                        break;
                    case 1:
                        // enemyTow CarroBomba
                        enemy = Instantiate(enemyTow, new Vector3(0, 0, 0), Quaternion.Euler(180, 90, -90));
                        enemy.transform.position = new Vector3(Random.Range(-7, 7), Random.Range(4f, 7), 5.5f);
                      
                        break;
                }
            }
            yield return new WaitForSeconds(tiempoSpawn); //veriable tiempoSpawn incrementa segun la funcion TiempoDeSpawn
        }
    }

    // spawnea myItem que aumenta la velocidad de la corrutina 
    public void VelocidadDeDisparo() 
    {
        GameObject myItem;
        myItem = Instantiate(speedObject, new Vector3(Random.Range(-7, 7), 7, 5), Quaternion.Euler(-90,0,0));
        myItem.AddComponent<CadenciaDeDisparo>();
        myItem.AddComponent<Rigidbody>();
        myItem.GetComponent<Rigidbody>().useGravity = false;
        myItem.GetComponent<BoxCollider>().isTrigger =  true;
    }
    // cambia de tipo de bala
    public void bullets ()
    {
        GameObject myAmmo;
        myAmmo = Instantiate(ammo, new Vector3(Random.Range(-7, 7),7, 5), Quaternion.Euler(-90,0,0));
        myAmmo.AddComponent<TipoDeBala>();
        myAmmo.AddComponent<Rigidbody>();
        myAmmo.GetComponent<Rigidbody>().useGravity = false;
        myAmmo.GetComponent<BoxCollider>().isTrigger = true;
    }
    // condicion de victoria
    public void Win ()
    {
     Winner.text = "Winner";
     ganador = false;
    }
    // condicion de derrota F
    public void Lose ()
    {
        if (numeroDeVidas <= 0 && temporal == true)
        {
            gameOver.text = "Game Over";
            inGame = false;
            tiempofuera = false;
            PlaySonidoGameOver();
            temporal = false;
        }
        if (myCasas <= 0 && temporal == true)
        {
            temporal = false;
            gameOver.text = "Game Over";
            inGame = false;
            tiempofuera = false;
            PlaySonidoGameOver();
        }
        if (casa.casaDestruida == false)
        {
            myCasas = myCasas - 1;
            casa.casaDestruida = true;
        }

    }
    // aumeto de dificultad
    public void TiempoDeSpawn ()
    {
        if (contraReloj >= 50f)
        {
            tiempoSpawn = 5f;
        }
        if (contraReloj >= 90f)
        {
            tiempoSpawn = 4f;
        }

    }
    //funciones para implementar el sonido
    public void PlaysonidoDestruccion()
    {
        AudioSource.PlayClipAtPoint(audioDestruccion, Camera.main.transform.position);
    }
    public void PlaySonidoDiparoEnemigo()
    {
        AudioSource.PlayClipAtPoint(audioDisparoEnemigo, Camera.main.transform.position);
    }
    public void PlaySonidoDisparaJefe ()
    {
        AudioSource.PlayClipAtPoint(audioDisparoJefe, Camera.main.transform.position);
    }
    public void PlaySonidoBala()
    {
        AudioSource.PlayClipAtPoint(audioBala, Camera.main.transform.position);
        
    }
    public void PlaySonidoBom()
    {
        AudioSource.PlayClipAtPoint(audioBom, Camera.main.transform.position);
    }
    public void PlaySonidoBurro()
    {
        AudioSource.PlayClipAtPoint(audioBurro, Camera.main.transform.position);
    }
    public void PlaySonidoMurteBurro()
    {
        AudioSource.PlayClipAtPoint(audioMuerteBurro, Camera.main.transform.position);
    }
    public void PlaySonidoEscudo()
    {
        AudioSource.PlayClipAtPoint(audioEscudo, Camera.main.transform.position);

    }
    public void PlaySonidoMuerteJefe()
    {
        AudioSource.PlayClipAtPoint(audioMuerteJefe, Camera.main.transform.position);

    }
    public void PlaySonidoGameOver()
    {
        AudioSource.PlayClipAtPoint(audioGameOver,Camera.main.transform.position);
    }
    // deteccion de coliciones 
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BalaEnemiga>())
        {
            PuntoDeVida = PuntoDeVida - 10;
        }
        if (other.GetComponent<BombCar>())
        {
            PuntoDeVida = PuntoDeVida - 50;
        }
        if (PuntoDeVida <= 0)
        {
            inmortal = false;
            numeroDeVidas = numeroDeVidas - 1; 
            PuntoDeVida = 100;
        }

    }


}
  
