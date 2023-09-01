using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Location", menuName = "LifeInRad/Location")]

public class Location : ScriptableObject
{
    public List<Sublocation> Sublocations;
}
