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
      _calculator.OnErrorOccurred += OpenWarningWindow;
      _warningService.OnCloseWindow += ActivateCalculatorView;
      
      await _calculator.Initialize(); 
      await _warningService.Initialize();

      ActivateCalculatorView();
    }

    public void Exit()
    {
      _calculator.OnErrorOccurred -= OpenWarningWindow;
      _warningService.OnCloseWindow -= ActivateCalculatorView;

      _warningService.Quit();
      _calculator.Quit();
    }

    private void ActivateCalculatorView() => 
      _calculator.SetActive(true);

    private void OpenWarningWindow()
    {
      _warningService.OpenWindow();
      _calculator.SetActive(false);
    }
  }
}