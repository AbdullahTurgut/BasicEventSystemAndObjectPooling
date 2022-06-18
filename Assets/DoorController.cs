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

    //bu durum abonelik durumu tabi abonelikten ��kma durumuda var
    private void Register()
    {
        //bu asl�nda kay�t olma durumudur
        GameEvents.instance.onDoorTriggerEnter += �nstance_onDoorTriggerEnter;
        GameEvents.instance.onDoorTriggerExit += �nstance_onDoorTriggerExit;
        //not burdaki instance GameEvents de startda �al��t�r�ld��� i�in 
        //hangisinin daha �nce �al��t�r�lca�� bilinmiyor bu y�zden instance null d�n�cektir
        //bunun �n�ne ge�mek i�in edit k�sm�nda projeSettingste script �ncelik s�ras�na ekleme yap�cam
        isRegistered = true;
    }

    //Abonelikden ��kma durumu
    private void UnRegister()
    {
        //bu asl�nda kay�t olma durumudur
        GameEvents.instance.onDoorTriggerEnter -= �nstance_onDoorTriggerEnter;
        GameEvents.instance.onDoorTriggerExit -= �nstance_onDoorTriggerExit;
        //not burdaki instance GameEvents de startda �al��t�r�ld��� i�in 
        //hangisinin daha �nce �al��t�r�lca�� bilinmiyor bu y�zden instance null d�n�cektir
        //bunun �n�ne ge�mek i�in edit k�sm�nda projeSettingste script �ncelik s�ras�na ekleme yap�cam
        isRegistered = false;
    }

    //abonelikten kap� yok edildi�inde ��k�labilir 
    private void OnDestroy()
    {
        UnRegister();
    }

    //tabi id parametresini burdada kullan�caz
    private void �nstance_onDoorTriggerExit(object sender, EventArgs args)
    {
        DoorTriggerEventsArgs doorArgs = (DoorTriggerEventsArgs)args;
        if (this.id == doorArgs.id)
        {
            LeanTween.moveLocalY(gameObject, 0.005f, 1f).setEaseInOutQuad();//trigger exit oldu�unda kap�y� kapatmak i�in
        }
        
    }

    private void �nstance_onDoorTriggerEnter(object sender,EventArgs args)
    {
        DoorTriggerEventsArgs doorArgs = (DoorTriggerEventsArgs)args;

        //tabi burda her kap�y� a�mak yerine idleri kar��la�t�r�p a�t�r�caz 
        if (this.id == doorArgs.id)
        {
            //burdaki this.id doorController scriptinin oldu�u kap�n�n id'si
            //kap�n�n trigger durumunda y ekseninde yukar� ��kmas�n� sa�lamak i�in 
            LeanTween.moveLocalY(gameObject, 1.005f, 1f).setEaseInOutQuad();//asset ile animasyon efekti sa�lamak i�in
        }
        //Burdaki tarihide DebugLogla yazd�ral�m
        Debug.Log("at " + doorArgs.dateTime + " there is an invasion");
    }

    //�rne�in mouse ile kap�ya t�klad���m�zda bir �ey yapmak istiyoruz 
    private void OnMouseDown()
    {
        //Not: burda t�klanma olunca kapn�n d���ndaki trigger area colliderine �arpt��� i�in t�klama ���n� 
        //�gnore Raycast yap�caz TriggerAreadaki colliderlar�
        if (isRegistered)
        {
            UnRegister();
            //kap�ya t�klad���m�zda rengini mavi yap�cak mesela
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            Register();
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
    }
}
