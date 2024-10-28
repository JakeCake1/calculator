using _Project.Scripts.Application.StateMachine.Interfaces;
using _Project.Scripts.Calculator;
using _Project.Scripts.WarningService;
using UnityEngine;

namespace _Project.Scripts.Application.StateMachine.States
{
  public sealed class ApplicationState : IApplicationState
  {
    private readonly IWarningService _warningService;
    private readonly ICalculator _calculator;

    public ApplicationState(ICalculator calculator, IWarningService warningService)
    {
      _calculator = calculator;
      _warningService = warningService;
    }
    
    public void SetStateMachine(IApplicationStateMachine applicationStateMachine)
    { }

    public async void Enter()
    {
      Debug.Log("Enter ApplicationState");

      _calculator.OnErrorOccurred += _warningService.OpenWindow;
      
      await _calculator.Initialize();
      await _warningService.Initialize();

      _calculator.OpenWindow();
    }

    public void Exit()
    {
      _calculator.OnErrorOccurred -= _warningService.OpenWindow;

      Debug.Log("Exit ApplicationState");
    }
  }
}