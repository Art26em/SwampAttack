using System;
using UnityEngine;

public class TargetDieTransition : Transition
{
    private void Update()
    {
        if (!Target)
        {
            NeedTransit = true;
        }
    }
}
