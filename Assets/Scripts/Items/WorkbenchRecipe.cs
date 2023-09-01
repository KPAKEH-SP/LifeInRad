using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WorkbenchItemRecipe", menuName = "LifeInRad/Items/WorkbenchItemRecipe")]

public class WorkbenchRecipe : ScriptableObject
{
    public List<Row> RecipeMesh;
}
