using _Project.Scripts.Application.StateMachine.Interfaces;
using UnityEngine;

namespace _Project.Scripts.Application.StateMachine.States
{
  public sealed class ApplicationState : IApplicationState
  {
    public void SetStateMachine(IApplicationStateMachine applicationStateMachine)
    { }

    public void Enter() => 
      Debug.Log("Enter ApplicationState");

    public void Exit() => 
      Debug.Log("Exit ApplicationState");
  }
}