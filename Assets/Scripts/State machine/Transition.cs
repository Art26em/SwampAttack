using System;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] protected State targetState;
    
    protected Player Target {get; private set;}
    public State TargetState => targetState;
    public bool NeedTransit {get; protected set;}
    
    public void Init(Player target)
    {
        Target = target;
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }
}
