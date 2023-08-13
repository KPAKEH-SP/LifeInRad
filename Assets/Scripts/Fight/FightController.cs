using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightController : MonoBehaviour
{
    [SerializeField] private Player _playerScript;
    [SerializeField] private Enemy _enemyScript;
    [SerializeField] private Button _attackButton;

    public void Attack()
    {
        StartCoroutine(AttackCoolDown());
    }

    private IEnumerator AttackCoolDown()
    {
        _playerScript.Attack(_enemyScript);
        //_attackButton.interactable = false;
        yield return new WaitForSeconds(1.5f);
        _enemyScript.Attack(_playerScript);
        yield return new WaitForSeconds(1.5f);
        //_attackButton.interactable = true;
    }
}
