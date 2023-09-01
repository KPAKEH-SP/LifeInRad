using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CustomEvent : MonoBehaviour
{
    public string EventName;
    public abstract void StartEvent();
    public abstract void EndEvent();
}
