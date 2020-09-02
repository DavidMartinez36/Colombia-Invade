using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class escudo : MonoBehaviour
{
    public float tiempoInmortal = 3f; 
    public float velocidad;
    public TextMeshProUGUI inmortal; 
    public GameObject  myEscudo; 

    void Update()
    {
        TiempoInmor();
    }
    public void TiempoInmor()
    {
        if (Spawner.inmortal == false)
        {
            tiempoInmortal -= Time.deltaTime;
            inmortal.text = "escudo: "+ tiempoInmortal.ToString("f0");
            myEscudo.SetActive(true);
        }
        if (tiempoInmortal <= 0)
        {
            Spawner.inmortal = true;
            myEscudo.SetActive(false);
            tiempoInmortal = 3f;
            inmortal.text = "";
        }
    }
}
