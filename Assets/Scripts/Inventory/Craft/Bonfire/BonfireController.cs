using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonfireController : MonoBehaviour
{
    [SerializeField] private List<Item> _recipesList;
    [SerializeField] private List<Slot> _craftSlots;
    [SerializeField] private ResultSlot _resultSlot;
    
    public void Fry()
    {
        int resemblance = 0;

        if (_resultSlot.StorageItem == null)
        {
            foreach (var item in _recipesList)
            {
                for (var itemId = 0; itemId < item.BonfireItemRecipe.Ingredients.Count; itemId++)
                {
                    if (item.BonfireItemRecipe.Ingredients[itemId] == _craftSlots[itemId].StorageItem)
                    {
                        resemblance++;
                    }
                }

                if (resemblance == 2)
                {
                    _resultSlot.Add(item);
                    foreach (var slot in _craftSlots)
                    {
                        if (slot.StorageItem != null && slot.StorageItem.ClearAfterCrafting == true) //Удаление предмета, если он должен удалиться при крафте
                        {
                            slot.Clear();
                        }

                        if (slot.StorageItem != null && slot.StorageItem.ItemAfterCrafting != null) //Замена предмета, если после крафта он меняется на другой
                        {
                            Item newItem = slot.StorageItem.ItemAfterCrafting;
                            slot.Clear();
                            slot.Add(newItem);
                        }
                    }
                }

                resemblance = 0;
            }
        }
    }
}
