using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "LifeInRad/Enemy")]

public class EnemyVariation: ScriptableObject
{
    public string EnemyName;
    public List<Armor> Armor;
    public int Hp;
    public int Strength;
}
