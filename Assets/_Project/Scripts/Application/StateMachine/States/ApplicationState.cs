using _Project.Scripts.Application.StateMachine.Interfaces;
using _Project.Scripts.WarningService;
using UnityEngine;

namespace _Project.Scripts.Application.StateMachine.States
{
  public sealed class ApplicationState : IApplicationState
  {
    private readonly IWarningService _warningService;

    public ApplicationState(IWarningService warningService)
    {
      _warningService = warningService;
    }
    
    public void SetStateMachine(IApplicationStateMachine applicationStateMachine)
    { }

    public void Enter()
    {
      Debug.Log("Enter ApplicationState");
      _warningService.OpenWindow();
    }

    public void Exit() => 
      Debug.Log("Exit ApplicationState");
  }
}