using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateFight : IState
{
    private Animator _playerAnimator;
    private Animator _enemyAnimator;
    private Animator _attackButtonAnimator;
    private Button _nextLocationButton;
    public StateFight(Animator playerAnim, Animator enemyAnim, Animator attackButtonAnim, Button nextLocationButton) 
    {
        _playerAnimator = playerAnim;
        _enemyAnimator = enemyAnim;
        _attackButtonAnimator = attackButtonAnim;
        _nextLocationButton = nextLocationButton;
    }
    public void Enter()
    {
        _nextLocationButton.interactable = false;
        _playerAnimator.Play("EnterFight");
        _enemyAnimator.gameObject.SetActive(true);
        _enemyAnimator.Play("EnterFight");
        _attackButtonAnimator.gameObject.SetActive(true);
        _attackButtonAnimator.Play("EnterFight");
        _attackButtonAnimator.SetBool("Exit", false);
    }

    public void Exit()
    {
        _nextLocationButton.interactable = true;
        _playerAnimator.Play("ExitFight");
        _enemyAnimator.Play("ExitFight");
        _attackButtonAnimator.SetBool("Exit", true);
    }

    public void Update()
    {
        
    }
}
