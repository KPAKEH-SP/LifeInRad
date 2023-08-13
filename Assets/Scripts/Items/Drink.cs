using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Drink", menuName = "LifeInRad/Items/Drink")]

public class Drink : Item
{
    public int ThirstReplenishment;
    public override void Use(Slot UsableSlot)
    {
        BarsController.Singletone.AllBars[1].ChangeValue(ThirstReplenishment);
        UsableSlot.Clear();
    }
}
