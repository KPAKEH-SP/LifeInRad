using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemRecipe", menuName = "LifeInRad/Items/ItemRecipe")]

public class Recipe : ScriptableObject
{
    public List<Row> RecipeMesh;
}
