using UnityEngine;

public abstract class Item : ScriptableObject 
{
    public Recipe ItemRecipe;
    public Sprite Icon;
    public int Id;
    [Range(0, 100)] public int Chance;
    abstract public void Use(Slot UsableSlot);
}