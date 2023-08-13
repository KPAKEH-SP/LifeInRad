using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class CraftSlot : Slot, IDropHandler
{
    [SerializeField] private int row, column;
    
    public new void OnDrop(PointerEventData eventData)
    {
        Drop(eventData);
        CraftController.Singletone.CraftMesh[row].Columns[column] = StorageItem;
    }

    public void ClearCraftSlot()
    {
        CraftController.Singletone.CraftMesh[row].Columns[column] = null;
    }
}
