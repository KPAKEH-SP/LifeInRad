using UnityEngine;
using System.Collections.Generic;

public abstract class Inventory : MonoBehaviour 
{
    public List<Slot> Slots;
    public abstract void Generate(List<Item> generatedItems);
    public void Clear()
    {
        foreach (var item in Slots)
        {
            item.Clear();
        }
    }
}