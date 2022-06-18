using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool isRegistered=true;
    public int id;
    void Start()
    {
        //if (!isRegistered)
        //{
        //    Register();
        //}
    }

    //bu durum abonelik durumu tabi abonelikten çýkma durumuda var
    private void Register()
    {
        //bu aslýnda kayýt olma durumudur
        GameEvents.instance.onDoorTriggerEnter += Ýnstance_onDoorTriggerEnter;
        GameEvents.instance.onDoorTriggerExit += Ýnstance_onDoorTriggerExit;
        //not burdaki instance GameEvents de startda çalýþtýrýldýðý için 
        //hangisinin daha önce çalýþtýrýlcaðý bilinmiyor bu yüzden instance null dönücektir
        //bunun önüne geçmek için edit kýsmýnda projeSettingste script öncelik sýrasýna ekleme yapýcam
        isRegistered = true;
    }

    //Abonelikden çýkma durumu
    private void UnRegister()
    {
        //bu aslýnda kayýt olma durumudur
        GameEvents.instance.onDoorTriggerEnter -= Ýnstance_onDoorTriggerEnter;
        GameEvents.instance.onDoorTriggerExit -= Ýnstance_onDoorTriggerExit;
        //not burdaki instance GameEvents de startda çalýþtýrýldýðý için 
        //hangisinin daha önce çalýþtýrýlcaðý bilinmiyor bu yüzden instance null dönücektir
        //bunun önüne geçmek için edit kýsmýnda projeSettingste script öncelik sýrasýna ekleme yapýcam
        isRegistered = false;
    }

    //abonelikten kapý yok edildiðinde çýkýlabilir 
    private void OnDestroy()
    {
        UnRegister();
    }

    //tabi id parametresini burdada kullanýcaz
    private void Ýnstance_onDoorTriggerExit(object sender, EventArgs args)
    {
        DoorTriggerEventsArgs doorArgs = (DoorTriggerEventsArgs)args;
        if (this.id == doorArgs.id)
        {
            LeanTween.moveLocalY(gameObject, 0.005f, 1f).setEaseInOutQuad();//trigger exit olduðunda kapýyý kapatmak için
        }
        
    }

    private void Ýnstance_onDoorTriggerEnter(object sender,EventArgs args)
    {
        DoorTriggerEventsArgs doorArgs = (DoorTriggerEventsArgs)args;

        //tabi burda her kapýyý açmak yerine idleri karþýlaþtýrýp açtýrýcaz 
        if (this.id == doorArgs.id)
        {
            //burdaki this.id doorController scriptinin olduðu kapýnýn id'si
            //kapýnýn trigger durumunda y ekseninde yukarý çýkmasýný saðlamak için 
            LeanTween.moveLocalY(gameObject, 1.005f, 1f).setEaseInOutQuad();//asset ile animasyon efekti saðlamak için
        }
        //Burdaki tarihide DebugLogla yazdýralým
        Debug.Log("at " + doorArgs.dateTime + " there is an invasion");
    }

    //örneðin mouse ile kapýya týkladýðýmýzda bir þey yapmak istiyoruz 
    private void OnMouseDown()
    {
        //Not: burda týklanma olunca kapnýn dýþýndaki trigger area colliderine çarptýðý için týklama ýþýný 
        //Ýgnore Raycast yapýcaz TriggerAreadaki colliderlarý
        if (isRegistered)
        {
            UnRegister();
            //kapýya týkladýðýmýzda rengini mavi yapýcak mesela
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            Register();
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
    }
}
