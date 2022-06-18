using System;


//EventArgs'�n alt clas� olarak olu�turduk
public class DoorTriggerEventsArgs : EventArgs
{
    //burda herhangi bir arg�man olabilir id dateTime kafam�za g�re 
    public int id { get; private set; }
    public DateTime dateTime { get; private set; }//olay�n meydana gelme zaman� asl�nda

    //ctor
    public DoorTriggerEventsArgs(int id)
    {
        this.id = id;
        dateTime = DateTime.Now;
    }
}
