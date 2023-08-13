using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateController : MonoBehaviour
{
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private Animator _enemyAnimator;
    [SerializeField] private Animator _attackButtonAnimator;
    [SerializeField] private Button _nextLocationButton;

    private Dictionary<Type, IState> _states;
    private IState _currentState;

    private void Start()
    {
        InitStates();
        SetStateByDefault();
    }

    private void InitStates()
    { 
        _states = new Dictionary<Type, IState>();

        _states[typeof(StateLoot)] = new StateLoot();
        _states[typeof(StateFight)] = new StateFight(_playerAnimator, _enemyAnimator, _attackButtonAnimator, _nextLocationButton);
    }

    private void SetState(IState newState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = newState;
        _currentState.Enter();
    }

    private void SetStateByDefault()
    {
        var stateByDefault = GetState<StateLoot>();
        SetState(stateByDefault);
    }

    private IState GetState<T>() where T : IState
    {
        var type = typeof(T);
        return _states[type];
    }

    private void Update()
    {
        if (_currentState != null) 
        { 
            _currentState.Update();
        }
    }

    public void SetStateFight()
    {
        var state = GetState<StateFight>();
        SetState(state);
    }

    public void SetStateLoot()
    {
        var state = GetState<StateLoot>();
        SetState(state);
    }
}
