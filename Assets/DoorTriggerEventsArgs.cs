using System;


//EventArgs'ýn alt clasý olarak oluþturduk
public class DoorTriggerEventsArgs : EventArgs
{
    //burda herhangi bir argüman olabilir id dateTime kafamýza göre 
    public int id { get; private set; }
    public DateTime dateTime { get; private set; }//olayýn meydana gelme zamaný aslýnda

    //ctor
    public DoorTriggerEventsArgs(int id)
    {
        this.id = id;
        dateTime = DateTime.Now;
    }
}
