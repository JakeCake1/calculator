using _Project.Scripts.Application.StateMachine.Interfaces;
using _Project.Scripts.SaveDataService.Interfaces;
using _Project.Scripts.WarningService;
using UnityEngine;

namespace _Project.Scripts.Application.StateMachine.States
{
  public sealed class StartupState : IApplicationState
  {
    private readonly ISaveDataService _saveDataService;
    private readonly IWarningService _warningService;

    private IApplicationStateMachine _applicationStateMachine;

    public StartupState(ISaveDataService saveDataService, IWarningService warningService)
    {
      _warningService = warningService;
      _saveDataService = saveDataService;
    }

    public void SetStateMachine(IApplicationStateMachine applicationStateMachine) => 
      _applicationStateMachine = applicationStateMachine;

    public async void Enter()
    {
      Debug.Log("Enter StartupState");
      
      _saveDataService.Load();
      await _warningService.Initialize();
      
      _applicationStateMachine.Enter<ApplicationState>();
    }

    public void Exit() => 
      Debug.Log("Exit StartupState");
  }
}