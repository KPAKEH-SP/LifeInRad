using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Sublocation", menuName = "LifeInRad/Sublocation")]

public class Sublocation : ScriptableObject 
{
    public List<string> NextLocationButtonTexts;
    public Sprite BackGround;
    public string Name;
    public Sprite Icon;
    public List<GeneratedItemElement> GeneratedItems;
    public List<GeneratedEnemiesElement> GeneratedEnemies;

    [Header("Описания для локации")]
    public List<string> Descriptions;
    public List<string> EnemyDescriptions;
    public List<string> EmptyDescriptions;
}

[System.Serializable]

public class GeneratedItemElement
{
    public Item GeneratedItem;
    [Range(0, 100)] public int Chance;
}

[System.Serializable]

public class GeneratedEnemiesElement
{
    public EnemyVariation GeneratedEnemy;
    [Range(0, 100)] public int Chance;
}