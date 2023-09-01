using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonfireEvent : CustomEvent
{
    [SerializeField] private GameObject _bonfireMenu;
    public override void StartEvent()
    {
        _bonfireMenu.SetActive(true);
    }

    public override void EndEvent()
    {
        _bonfireMenu.SetActive(false);
    }
}
