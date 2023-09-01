using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomEventController : MonoBehaviour
{
    public List<CustomEvent> Events;

    public static CustomEventController Singletone;

    private void Awake()
    {
        if (Singletone == null)
        {
            Singletone = this;
        }

        else
        {
            Destroy(this.gameObject);
        }
    }
}
