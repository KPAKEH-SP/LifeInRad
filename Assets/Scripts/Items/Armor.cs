using UnityEngine;

[CreateAssetMenu(fileName = "Armor", menuName = "LifeInRad/Items/Armor")]

public class Armor : Item
{
    public Sprite Texture;
    public int Protection;
    public TypeEnum Type = TypeEnum.Head;
    public enum TypeEnum
    {
        Head,
        Body,
        Legs
    };

    public override void Use(Slot UsableSlot)
    {

    }
}