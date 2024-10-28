using _Project.Scripts.Application.StateMachine.Interfaces;
using _Project.Scripts.SaveDataService.Interfaces;
using UnityEngine;

namespace _Project.Scripts.Application.StateMachine.States
{
  public sealed class StartupState : IApplicationState
  {
    private readonly ISaveDataService _saveDataService;

    private IApplicationStateMachine _applicationStateMachine;

    public StartupState(ISaveDataService saveDataService) => 
      _saveDataService = saveDataService;

    public void SetStateMachine(IApplicationStateMachine applicationStateMachine) => 
      _applicationStateMachine = applicationStateMachine;

    public void Enter()
    {
      Debug.Log("Enter StartupState");
      
      _saveDataService.Load();
      _applicationStateMachine.Enter<ApplicationState>();
    }

    public void Exit() => 
      Debug.Log("Exit StartupState");
  }
}