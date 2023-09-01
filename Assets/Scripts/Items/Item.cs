using UnityEngine;

public abstract class Item : ScriptableObject 
{
    public Sprite Icon;
    public int Id;
    [Header("Система крафта")]
    public WorkbenchRecipe WorkbenchItemRecipe;
    public BonfireRecipe BonfireItemRecipe;
    public bool ClearAfterCrafting;
    public Item ItemAfterCrafting;
    abstract public void Use(Slot UsableSlot);
}