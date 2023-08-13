using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinusBar : Bar
{
    private void Start()
    {
        StartCoroutine(ChangeBar());
    }

    public override IEnumerator ChangeBar()
    {
        _fill.value -= _changeValue;
        yield return new WaitForSeconds(_time);
        StartCoroutine(ChangeBar());
    }
}
