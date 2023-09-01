using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

public class LocationController : MonoBehaviour 
{
    [SerializeField] private NextLocation _nextLocationScript;
    [SerializeField] private SublocationPosition _sublocationPosition;
    [SerializeField] private DescriptionController _descriptionController;
    public Coroutine _currentCoroutine;

    [Header("Для генерации предметов")]
    [SerializeField] private Inventory _inventory;
    private Sublocation _currentSublocation;
    private Sublocation _nextSublocation;
    private Location _currentLocation;
    private LocationButton _currentLocationButton;

    [Header("Для генерации локации")]
    [SerializeField] private LocationButton _startLocation;
    [SerializeField] private Image _backGround;
    [SerializeField] private Image _sublocationIcon;

    [Header("Для генерации монстров")]
    [SerializeField] private Enemy _enemy;
    private EnemyVariation _currentEnemy;

    [Header("Состояния")]
    [SerializeField] private StateController _stateController;

    void Start()
    {
        SetLocation(_startLocation);
    }

    public void GenerateSubocation()
    {
        _sublocationPosition.NextPosition();
        _currentCoroutine = StartCoroutine(ChangeButtonActive());
        _currentEnemy = null;
        _inventory.Clear();
        _currentSublocation = _nextSublocation;
        _sublocationIcon.sprite = _currentSublocation.Icon;
        _backGround.sprite = _currentSublocation.BackGround;

        GenerateMonster(_currentSublocation.GeneratedEnemies);


        if (_currentEnemy == null)
        {
            GenerateItems();
        }

        else
        {
            if (_currentCoroutine != null)
                StopCoroutine(_currentCoroutine);

            _nextLocationScript.NextLocationButtonEnabled = false;
        }
        GenerateNextSublocation();
    }

    public void GenerateNextSublocation()
    {
        _nextSublocation = _currentLocation.Sublocations[Random.Range(0, _currentLocation.Sublocations.Count)];
        _nextLocationScript.NextLocationButtonText = _nextSublocation.NextLocationButtonTexts[Random.Range(0, _nextSublocation.NextLocationButtonTexts.Count)];
    }

    public void GenerateItems()
    {
        _inventory.Generate(_currentSublocation.GeneratedItems);
        _stateController.SetStateLoot();

        if (_inventory.Slots[0].Filled == false)
            _descriptionController.GenerateDescription(_currentSublocation.EmptyDescriptions);

        else
            _descriptionController.GenerateDescription(_currentSublocation.Descriptions);
    }

    public void GenerateMonster(List<GeneratedEnemiesElement> generatedEnemies)
    {
        foreach (var enemy in generatedEnemies)
        {
            int chance = Random.Range(0, 101);

            if (chance <= enemy.Chance)
            {
                _enemy.Generate(enemy.GeneratedEnemy);
                _enemy.AttackPower = enemy.GeneratedEnemy.Strength;
                _enemy.HealthBar.maxValue = enemy.GeneratedEnemy.Hp;
                _enemy.HealthBar.value = enemy.GeneratedEnemy.Hp;
                _currentEnemy = enemy.GeneratedEnemy;
                _stateController.SetStateFight();
                _descriptionController.GenerateDescription(_currentSublocation.EnemyDescriptions);
                break;
            }
        }
    }

    private IEnumerator ChangeButtonActive()
    {
        _nextLocationScript.NextLocationButtonEnabled = false;
        yield return new WaitForSeconds(5);
        _nextLocationScript.NextLocationButtonEnabled = true;
    }

    public void SetLocation(LocationButton locationButton)
    {
        if (_currentLocationButton != null)
            _currentLocationButton.gameObject.GetComponent<Button>().interactable = true;
        
        _currentLocationButton = locationButton;
        _currentLocation = locationButton.LocationObject;
        _currentLocationButton.gameObject.GetComponent<Button>().interactable = false;
        _nextSublocation = _currentLocation.Sublocations[Random.Range(0, _currentLocation.Sublocations.Count)];
        GenerateSubocation();
    }
}