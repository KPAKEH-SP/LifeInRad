using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

public class LocationController : MonoBehaviour 
{
    public Button NextLocationButton;
    [SerializeField] private Image _icon;
    [SerializeField] private LocationPosition _locationPosition;
    public Coroutine _currentCoroutine;

    [Header("Для генерации предметов")]
    [SerializeField] private List<Location> _locations;
    [SerializeField] private Inventory _inventory;
    private Location _currentLocation;

    [Header("Для генерации монстров")]
    [SerializeField] private Enemy _enemy;
    private EnemyVariation _currentEnemy;

    [Header("Состояния")]
    [SerializeField] private StateController _stateController;

    void Start()
    {
        GenerateLocation();
    }

    public void GenerateLocation()
    {
        _locationPosition.NextPosition();
        _currentCoroutine = StartCoroutine(ChangeButtonActive());
        _currentEnemy = null;
        _inventory.Clear();
        _currentLocation = _locations[Random.Range(0, _locations.Count - 1)];
        _icon.sprite = _currentLocation.Icon;

        GenerateMonster(_currentLocation.GeneratedEnemies);


        if (_currentEnemy == null)
        {
            GenerateItems();
        }

        else
        {
            if (_currentCoroutine != null)
                StopCoroutine(_currentCoroutine);

            NextLocationButton.interactable = false;
        }
    }

    public void GenerateItems()
    {
        _inventory.Generate(_currentLocation.GeneratedItems);
        _stateController.SetStateLoot();
    }

    public void GenerateMonster(List<EnemyVariation> generatedEnemies)
    {
        foreach (var enemy in generatedEnemies)
        {
            int chance = Random.Range(0, 101);

            if (chance <= enemy.Chance)
            {
                _enemy.Generate(enemy);
                _enemy.AttackPower = enemy.Strength;
                _enemy.HealthBar.maxValue = enemy.Hp;
                _enemy.HealthBar.value = enemy.Hp;
                _currentEnemy = enemy;
                _stateController.SetStateFight();
                break;
            }
        }
    }

    private IEnumerator ChangeButtonActive()
    {
        NextLocationButton.interactable = false;
        yield return new WaitForSeconds(5);
        NextLocationButton.interactable = true;
    }
}