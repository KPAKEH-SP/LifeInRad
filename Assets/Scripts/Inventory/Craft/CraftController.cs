using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftController : MonoBehaviour
{
    public List<Row> CraftMesh;
    [SerializeField] private List<Item> _recipesList;
    [SerializeField] private List<CraftSlot> _craftSlots;
    [SerializeField] private ResultSlot _resultSlot;

    public static CraftController Singletone = null;

    private void Awake()
    {
        if (Singletone == null)
        {
            Singletone = this;
        }

        else
        {
            Destroy(this.gameObject);
        }
    }

    public void Craft()
    {
        if (_resultSlot.StorageItem == null)
        {
            int resemblance = 0;

            foreach (var recipe in _recipesList)
            {
                for (var row = 0; row < recipe.ItemRecipe.RecipeMesh.Count; row++)
                {
                    for (var column = 0; column < recipe.ItemRecipe.RecipeMesh[row].Columns.Count; column++)
                    {
                        if (recipe.ItemRecipe.RecipeMesh[row].Columns[column] == CraftMesh[row].Columns[column])
                        {
                            resemblance++;
                        }

                        else
                        {
                            break;
                        }
                    }
                }

                if (resemblance == 9)
                {
                    _resultSlot.Add(recipe);
                    foreach (var slot in _craftSlots)
                    {
                        slot.Clear();
                        slot.ClearCraftSlot();
                    }
                }
            }
        }
    }

}

[System.Serializable]

public class Row
{
    public List<Item> Columns;
}