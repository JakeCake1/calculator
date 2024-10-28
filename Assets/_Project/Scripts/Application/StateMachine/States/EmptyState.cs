using _Project.Scripts.Application.StateMachine.Interfaces;
using UnityEngine;

namespace _Project.Scripts.Application.StateMachine.States
{
  public sealed class EmptyState : IApplicationState
  {
    public void SetStateMachine(IApplicationStateMachine applicationStateMachine)
    { }

    public void Enter() => 
      Debug.Log("Enter EmptyState");

    public void Exit() => 
      Debug.Log("Exit EmptyState");
  }
}