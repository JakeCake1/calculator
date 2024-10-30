using _Project.Scripts.Application.StateMachine.ApplicationDependenciesInstaller;
using _Project.Scripts.Application.StateMachine.Interfaces;
using _Project.Scripts.Calculator;
using _Project.Scripts.Maths;
using _Project.Scripts.WarningService;
using VContainer;
using VContainer.Unity;

namespace _Project.Scripts.Application.StateMachine.States
{  
  /// \class ApplicationState
  /// \brief Класс-состояние, отвечающий за основную логику в приложении
  public sealed class ApplicationState : IApplicationState
  {
    /// \brief Сервис, вызывающий окно с предупреждением
    private IWarningService _warningService;
    /// \brief Логика калькулятора
    private ICalculator _calculator;
    
    /// \brief Объект - глобальная область существования, содержащий регистрацию инъекций сервисов для всего времени жизни приложения
    private readonly ApplicationLifetimeScope _applicationLifetimeScope;
    /// \brief Объект - область существования, содержащий регистрацию инъекций логики для этого состояния приложения
    private LifetimeScope _applicationScope;
    
    /// \brief Конструктор состояния
    /// \param applicationLifetimeScope   Объект - глобальная область существования, содержащий регистрацию инъекций сервисов для всего времени жизни приложения
    public ApplicationState(ApplicationLifetimeScope applicationLifetimeScope) => 
      _applicationLifetimeScope = applicationLifetimeScope;
   
    /// \brief Метод входа в состояние
    public async void Enter()
    {
      CreateApplicationStateDependencies();

      _calculator.OnErrorOccurred += OpenWarningWindow;
      _warningService.OnCloseWindow += ActivateCalculatorView;
      
      await _calculator.Initialize(); 
      await _warningService.Initialize();

      ActivateCalculatorView();
    }
    
    /// \brief Метод выхода из состояния
    public void Exit()
    {
      _calculator.OnErrorOccurred -= OpenWarningWindow;
      _warningService.OnCloseWindow -= ActivateCalculatorView;

      _warningService.Quit();
      _calculator.Quit();
      
      CleanupApplicationStateDependencies();
    }
    
    /// \brief Метод активации UI калькулятора
    private void ActivateCalculatorView() => 
      _calculator.SetActive(true);
    
    /// \brief Метод открытия окна-предупреждения
    private void OpenWarningWindow()
    {
      _warningService.OpenWindow();
      _calculator.SetActive(false);
    }
    
    /// \brief Создание и получение зависимостей для данного состояния приложения
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
    
    /// \brief Вызов очистки зависимостей для данного состояния приложения
    private void CleanupApplicationStateDependencies()
    {
      _applicationScope.Dispose();
      _applicationScope = null;
    }
  }
}