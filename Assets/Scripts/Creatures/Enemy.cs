using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Creature
{
    [SerializeField] private List<Image> _armor;
    [SerializeField] private StateController _stateController;
    [SerializeField] private LocationController _locationController;
    private EnemyVariation _currentEnemy;

    public override void Death()
    {
        _stateController.SetStateLoot();
        _locationController.GenerateItems();
        _locationController.NextLocationButton.interactable = true;
    }

    public void Generate(EnemyVariation generatedEnemy)
    {
        for (var itemId = 0; itemId < generatedEnemy.Armor.Count; itemId++) 
        {
            _armor[itemId].sprite = generatedEnemy.Armor[itemId].Texture;
            _currentEnemy = generatedEnemy;
        }
    }
}