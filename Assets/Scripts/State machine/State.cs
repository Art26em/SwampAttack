using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class State : MonoBehaviour
{
   [SerializeField] private List<Transition> transitions;
   
   protected Player Target {get; private set;}

   public void Enter(Player player)
   {
      if (enabled) return;
      Target = player;
      enabled = true;
      foreach (var transition in transitions)
      {
         transition.enabled = true;
         transition.Init(Target);
      }
   }

   public void Exit()
   {
      if (!enabled) return;
      enabled = false;
      foreach (var transition in transitions)
      {
         transition.enabled = false;
      }
   }
   
   public State GetNextState()
   {
      return (from transition in transitions where transition.NeedTransit select transition.TargetState).FirstOrDefault();
   }
   
}
