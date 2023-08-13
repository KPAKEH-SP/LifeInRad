using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Location", menuName = "LifeInRad/Location")]

public class Location : ScriptableObject 
{
    public string Name;
    public string Description;
    public Sprite Icon;
    public List<Item> GeneratedItems;
    public List<EnemyVariation> GeneratedEnemies;
}