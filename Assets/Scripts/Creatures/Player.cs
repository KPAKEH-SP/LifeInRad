using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Creature
{
    public static Player Singletone = null;
    [SerializeField] private List<Image> _armorSlots;
    [SerializeField] private List<Sprite> _standartArmorTextures;
    
    private void Awake()
    {
        if (Singletone == null)
        {
            Singletone = this;
        }

        else
        {
            Destroy(this.gameObject);
        }
    }

    public void ChangeArmorTextures(int armorType, Sprite armorTexture)
    {
        _armorSlots[armorType].sprite = armorTexture;
    }

    public void ResetArmorTextures(int armorType)
    {
        _armorSlots[armorType].sprite = _standartArmorTextures[armorType];
    }

    public override void Death()
    {
        Debug.Log("’а, ты сдох. Ћќ’");
    }
}