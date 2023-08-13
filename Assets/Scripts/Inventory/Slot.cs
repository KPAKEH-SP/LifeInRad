using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IDropHandler
{
    public Image ItemIcon;
    public Item StorageItem;
    public bool Filled = false;

    public void OnDrop(PointerEventData eventData)
    {
        Drop(eventData);
    }

    public void Drop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            DragItem dragableItem = eventData.pointerDrag.GetComponent<DragItem>();
            Item oldDragItem = dragableItem.ParentSlot.StorageItem;

            if (dragableItem.ParentSlot.StorageItem.GetType() == typeof(Armor) && dragableItem.ParentSlot.GetType() == typeof(EquipmentSlot)) //Проверка на то, вынимают ли броню из экипировочного слота
                ((EquipmentSlot)dragableItem.ParentSlot).ResetArmor();

            if (dragableItem.ParentSlot.StorageItem.GetType() == typeof(Weapon) && dragableItem.ParentSlot.GetType() == typeof(EquipmentSlot)) //Проверка на то, вынимают ли оружие из слота для оружия
                Player.Singletone.AttackPower -= ((Weapon)dragableItem.ParentSlot.StorageItem).Power;

            if (dragableItem.ParentSlot.GetComponent<CraftSlot>()) //Проверка на то, вынимают ли предмет из сетки крафта
                ((CraftSlot)dragableItem.ParentSlot).ClearCraftSlot();

            if (Filled == true)
                dragableItem.ParentSlot.Add(StorageItem); //Переносим предмет из этого слота в драг, есди в этом слоте был предмет 

            else
                dragableItem.ParentSlot.Clear(); // Очищаем драговый слот, если этот был пустой

            Add(oldDragItem); //Переносим предмет из драга в этот слот
            dragableItem.EndDrag();
        }
    }

    public void Add(Item AddedItem)
    {
        ItemIcon.gameObject.SetActive(true);
        ItemIcon.sprite = AddedItem.Icon;
        StorageItem = AddedItem;
        Filled = true;
    }

    public void Clear()
    {
        ItemIcon.gameObject.SetActive(false);
        ItemIcon.sprite = null;
        StorageItem = null;
        Filled = false;
    }

    public void Save()
    {

    }

    public void Load()
    {
        
    }
}