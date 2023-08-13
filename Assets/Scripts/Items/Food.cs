using UnityEngine;

[CreateAssetMenu(fileName = "Food", menuName = "LifeInRad/Items/Food")]

public class Food : Item 
{
    public int Nutritional;
    public override void Use(Slot UsableSlot)
    {
        BarsController.Singletone.AllBars[0].ChangeValue(Nutritional);
        UsableSlot.Clear();
    }
}