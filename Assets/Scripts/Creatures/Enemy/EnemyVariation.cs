using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "LifeInRad/Enemy")]

public class EnemyVariation: ScriptableObject
{
    public List<Armor> Armor;
    public int Hp;
    public int Strength;
    [Range(0,100)] public int Chance;
}
