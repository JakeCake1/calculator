using _Project.Scripts.Application.StateMachine.ApplicationDependenciesInstaller;
using _Project.Scripts.Application.StateMachine.Interfaces;
using _Project.Scripts.Calculator;
using _Project.Scripts.Maths;
using _Project.Scripts.WarningService;
using VContainer;
using VContainer.Unity;

namespace _Project.Scripts.Application.StateMachine.States
{
  public sealed class ApplicationState : IApplicationState
  {
    private IWarningService _warningService;
    private ICalculator _calculator;
    
    private readonly ApplicationLifetimeScope _applicationLifetimeScope;
    private LifetimeScope _applicationScope;

    public ApplicationState(ApplicationLifetimeScope applicationLifetimeScope) => 
      _applicationLifetimeScope = applicationLifetimeScope;

    public void SetStateMachine(IApplicationStateMachine applicationStateMachine)
    { }

    public async void Enter()
    {
      CreateApplicationStateDependencies();

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
      
      CleanupApplicationStateDependencies();
    }

    private void ActivateCalculatorView() => 
      _calculator.SetActive(true);

    private void OpenWarningWindow()
    {
      _warningService.OpenWindow();
      _calculator.SetActive(false);
    }

    private void CreateApplicationStateDependencies()
    {
      _applicationScope = _applicationLifetimeScope.CreateChild(builder =>
      {
        new WarningServiceInstaller().Install(builder);
        new MathsInstaller().Install(builder);
        new CalculatorInstaller().Install(builder);
      });
      
      _warningService = _applicationScope.Container.Resolve<IWarningService>();
      _calculator = _applicationScope.Container.Resolve<ICalculator>();
    }

    private void CleanupApplicationStateDependencies()
    {
      _applicationScope.Dispose();
      _applicationScope = null;
    }
  }
}