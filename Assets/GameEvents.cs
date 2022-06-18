using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    //Heryerden eri�ebilir olmas�n� sa�lamam�z i�in bir instance laz�m bize
    public static GameEvents instance;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    //Bu a�a��daki durum birden fazla kap� oldu�unda hepsini a��cak o y�zden bir parametre ile id vericez ve gitti�imiz kap�n�n
    //a��lmas�n� sa�layaca��z
    /// <summary>
    /// BURDAK� OLAYI DELEGATE �LE DE YAPAB�L�YORUZ ONUDA ��YLE G�STER�CEM
    /// </summary>
    //public event Action<int> onDoorTriggerEnter;//Actionlar delegate gibi ge�er fonksiyon tutucudur.
    //public event Action<int> onDoorTriggerExit;

    public delegate void DoorTriggerEvent(object sender, EventArgs args);
    public event DoorTriggerEvent onDoorTriggerEnter;
    public event DoorTriggerEvent onDoorTriggerExit;



    //Burdaki id parametresi asl�nda triggerArea daki kap� k�sm�nda olucak
    public void DoorTriggerEnter(int id)
    {
        //bu method �a�r�ld���nda abonelik varm� yokmu ona bak�caz
        if(onDoorTriggerEnter != null)
        {
            //parametre olarak g�ndermek i�in
            DoorTriggerEventsArgs args = new DoorTriggerEventsArgs(id);
            //sender olarak this, arg�man olarak args g�nderdik
            onDoorTriggerEnter(this,args);//bunu art�k method olarak �a��rcak biz doldurucaz
        }
    }
    public void DoorTriggerExit(int id)
    {
        if (onDoorTriggerExit != null)
        {
            DoorTriggerEventsArgs args = new DoorTriggerEventsArgs(id);
            onDoorTriggerExit(this,args);//bunu art�k method olarak �a��rcak biz doldurucaz
        }
    }
}
