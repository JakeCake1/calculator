using _Project.Scripts.Application.StateMachine.Interfaces;
using _Project.Scripts.SaveDataService.Interfaces;
using UnityEngine;

namespace _Project.Scripts.Application.StateMachine.States
{
  public sealed class StartupState : IApplicationState
  {
    private readonly ISaveDataService _saveDataService;
    private readonly IApplicationStateMachine _applicationStateMachine;

    public StartupState(ISaveDataService saveDataService, IApplicationStateMachine applicationStateMachine)
    {
      _saveDataService = saveDataService;
      _applicationStateMachine = applicationStateMachine;
    }
    
    public void Enter()
    {
      _saveDataService.Load();
      _applicationStateMachine.Enter<ApplicationState>();
    }

    public void Exit()
    { }
  }
}