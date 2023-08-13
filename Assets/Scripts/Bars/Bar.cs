using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Slider _fill;
    [SerializeField] protected float _time;
    [SerializeField] protected float _changeValue;

    public abstract IEnumerator ChangeBar();
    public void ChangeValue(int value)
    {
        _fill.value += value;
    }
}
