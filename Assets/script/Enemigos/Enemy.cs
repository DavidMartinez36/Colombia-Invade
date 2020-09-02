using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    public static bool speedIncrease = false;
    public static bool ammoTwo = false;
    public float pointLife = 100;
    public GameObject Bala;
    private void Awake()
    {
        speedIncrease = false;
        ammoTwo = false;
    }

}