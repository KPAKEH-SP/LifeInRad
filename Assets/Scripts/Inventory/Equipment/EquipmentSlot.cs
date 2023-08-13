using UnityEngine.EventSystems;
using UnityEngine;

public class EquipmentSlot : Slot, IDropHandler
{
    private Armor _storageArmor;
    private Weapon _storageWeapon;
    public TypeEnum Type = TypeEnum.Head;
    public enum TypeEnum
    {
        Head,
        Body,
        Legs,
        Weapon
    };

    public new void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.GetComponent<DragItem>().ParentSlot.StorageItem.GetType() == typeof(Weapon) && Type == TypeEnum.Weapon) //�������� �� ��, ����� ������ ���������� � ���� ������
        {
            _storageWeapon = (Weapon)eventData.pointerDrag.GetComponent<DragItem>().ParentSlot.StorageItem;
            Player.Singletone.AttackPower += _storageWeapon.Power;
            Drop(eventData);
        }

        else if (eventData.pointerDrag.GetComponent<DragItem>().ParentSlot.StorageItem.GetType() == typeof(Armor))
        {
            _storageArmor = (Armor)eventData.pointerDrag.GetComponent<DragItem>().ParentSlot.StorageItem; 

            if (_storageArmor.Type == Armor.TypeEnum.Head && Type == TypeEnum.Head) //�������� �� ��, ����� ���� ���������� � ���� �����
            {
                Drop(eventData);
                Player.Singletone.ChangeArmorTextures(0, _storageArmor.Texture);
            }

            else if (_storageArmor.Type == Armor.TypeEnum.Body && Type == TypeEnum.Body) //�������� �� ��, ����� ��������� ���������� � ���� ����������
            {
                Drop(eventData);
                Player.Singletone.ChangeArmorTextures(1, _storageArmor.Texture);
            }

            else if (_storageArmor.Type == Armor.TypeEnum.Legs && Type == TypeEnum.Legs) //�������� �� ��, ����� ����� ���������� � ���� ������
            {
                Drop(eventData);
                Player.Singletone.ChangeArmorTextures(2, _storageArmor.Texture);
            }
        }
    }

    public void ResetArmor()
    {
        if (Type == TypeEnum.Head)
        {
            Player.Singletone.ResetArmorTextures(0);
        }

        if (Type == TypeEnum.Body)
        {
            Player.Singletone.ResetArmorTextures(1);

        }

        if (Type == TypeEnum.Legs)
        {
            Player.Singletone.ResetArmorTextures(2);

        }
    }
}
