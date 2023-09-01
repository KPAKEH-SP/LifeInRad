using UnityEngine;
using System.Collections.Generic;

public class LocationInventory : Inventory 
{
    public override void Generate(List<GeneratedItemElement> generatedItems)
    {
        foreach (var item in generatedItems)
        {
            int chance = Random.Range(0, 101);
            
            if (chance <= item.Chance)
            {
                foreach (var slot in Slots)
                {
                    if (slot.Filled == false)
                    {
                        slot.Add(item.GeneratedItem);
                        break;
                    }
                }
            }
        }
    }
}