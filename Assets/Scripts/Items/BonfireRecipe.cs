using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BonfireItemRecipe", menuName = "LifeInRad/Items/BonfireItemRecipe")]


public class BonfireRecipe : ScriptableObject
{
    public List<Item> Ingredients;
}
