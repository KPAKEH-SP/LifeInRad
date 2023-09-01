using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.UI;

public class SublocationPosition : MonoBehaviour
{
    [SerializeField] private float _animationSpeed;
    [SerializeField] private Image _positionDisplay;
    [SerializeField] private Sprite _offDisplay;
    [SerializeField] private List<Position> _positions;
    private int _currentPosition = 2; //Значение 2 для того, что бы при первой генерации локации отображалась первая позиция
    private Coroutine _currentCoroutine;

    private void Start()
    {
        _currentCoroutine = StartCoroutine(Flicker());
    }

    public void NextPosition()
    {
        if (_currentPosition + 1 > _positions.Count - 1)
        {
            _currentPosition = 0;
        }

        else
        {
            StartCoroutine(NextPositionAnimation());
            _currentPosition++;
        }
    }

    private IEnumerator Flicker()
    {
        _positionDisplay.sprite = _positions[_currentPosition].PositionSprite;
        yield return new WaitForSeconds(Random.Range(1, 4));
        _positionDisplay.sprite = _offDisplay;
        yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));
        _currentCoroutine = StartCoroutine(Flicker());
    }

    private IEnumerator NextPositionAnimation()
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        foreach (var frame in _positions[_currentPosition].Animation)
        {
            _positionDisplay.sprite = frame;
            yield return new WaitForSeconds(_animationSpeed);
        }

        _currentCoroutine = StartCoroutine(Flicker());
    }
}

[System.Serializable]

public class Position
{
    public Sprite PositionSprite;
    public List<Sprite> Animation;
}