using System;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State firstState;
    
    private Player _target;
    private State _currentState;
    
    public State Current => _currentState;
    
    private void Start()
    {
        _target = GetComponent<Enemy>().Target;
        ResetState(firstState);
    }
    
    private void Update()
    {
        if (!_currentState) 
            return;
        
        var nextState = _currentState.GetNextState();

        if (nextState)
        {
            Transit(nextState);    
        }
        
    }

    private void ResetState(State startState)
    {
        _currentState = startState;
        if (_currentState)
        {
            _currentState.Enter(_target);
        }
    }

    private void Transit(State nextState)
    {
        if (_currentState)
        {
            _currentState.Exit();
        }   
        
        _currentState = nextState;

        if (_currentState)
        {
            _currentState.Enter(_target);
        }
        
    }
    
}
