using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class WorkbenchController : MonoBehaviour
{
    public List<Row> CraftMesh;
    [SerializeField] private List<Item> _recipesList;
    [SerializeField] private List<CraftSlot> _craftSlots;
    [SerializeField] private ResultSlot _resultSlot;

    public static WorkbenchController Singletone = null;

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
                for (var row = 0; row < recipe.WorkbenchItemRecipe.RecipeMesh.Count; row++)
                {
                    for (var column = 0; column < recipe.WorkbenchItemRecipe.RecipeMesh[row].Columns.Count; column++)
                    {
                        if (recipe.WorkbenchItemRecipe.RecipeMesh[row].Columns[column] == CraftMesh[row].Columns[column])
                        {
                            resemblance++;
                        }
                    }
                }

                if (resemblance == 9)
                {
                    _resultSlot.Add(recipe);
                    foreach (var slot in _craftSlots)
                    {
                        if (slot.StorageItem != null && slot.StorageItem.ClearAfterCrafting == true) //Удаление предмета, если он должен удалиться при крафте
                        {
                            slot.Clear();
                            slot.ClearCraftSlot();
                        }

                        if (slot.StorageItem != null && slot.StorageItem.ItemAfterCrafting != null) //Замена предмета, если после крафта он меняется на другой
                        {
                            Item newItem = slot.StorageItem.ItemAfterCrafting;
                            slot.Clear();
                            slot.ClearCraftSlot();
                            slot.Add(newItem);
                        }
                    }
                }

                resemblance = 0;
            }
        }
    }

}

[System.Serializable]

public class Row
{
    public List<Item> Columns;
}