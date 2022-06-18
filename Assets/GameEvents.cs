using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    //Heryerden eriþebilir olmasýný saðlamamýz için bir instance lazým bize
    public static GameEvents instance;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    //Bu aþaðýdaki durum birden fazla kapý olduðunda hepsini açýcak o yüzden bir parametre ile id vericez ve gittiðimiz kapýnýn
    //açýlmasýný saðlayacaðýz
    /// <summary>
    /// BURDAKÝ OLAYI DELEGATE ÝLE DE YAPABÝLÝYORUZ ONUDA ÞÖYLE GÖSTERÝCEM
    /// </summary>
    //public event Action<int> onDoorTriggerEnter;//Actionlar delegate gibi geçer fonksiyon tutucudur.
    //public event Action<int> onDoorTriggerExit;

    public delegate void DoorTriggerEvent(object sender, EventArgs args);
    public event DoorTriggerEvent onDoorTriggerEnter;
    public event DoorTriggerEvent onDoorTriggerExit;



    //Burdaki id parametresi aslýnda triggerArea daki kapý kýsmýnda olucak
    public void DoorTriggerEnter(int id)
    {
        //bu method çaðrýldýðýnda abonelik varmý yokmu ona bakýcaz
        if(onDoorTriggerEnter != null)
        {
            //parametre olarak göndermek için
            DoorTriggerEventsArgs args = new DoorTriggerEventsArgs(id);
            //sender olarak this, argüman olarak args gönderdik
            onDoorTriggerEnter(this,args);//bunu artýk method olarak çaðýrcak biz doldurucaz
        }
    }
    public void DoorTriggerExit(int id)
    {
        if (onDoorTriggerExit != null)
        {
            DoorTriggerEventsArgs args = new DoorTriggerEventsArgs(id);
            onDoorTriggerExit(this,args);//bunu artýk method olarak çaðýrcak biz doldurucaz
        }
    }
}
