using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EventItem", menuName = "LifeInRad/Items/EventItem")]

public class EventItem : Item
{
    [SerializeField] private string _eventName;
    public override void Use(Slot UsableSlot)
    {
        UsableSlot.Clear();
        
        foreach (var customEvent in CustomEventController.Singletone.Events) 
        {
            if (customEvent.EventName == _eventName)
            {
                customEvent.StartEvent();
            }
        }
    }
}
