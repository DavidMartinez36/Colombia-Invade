
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEsena : MonoBehaviour
{
    
    public void NivelUno()
    {
        SceneManager.LoadScene("play");
    }
    public void Controles()
    {
        SceneManager.LoadScene("Controles");     
        
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

}