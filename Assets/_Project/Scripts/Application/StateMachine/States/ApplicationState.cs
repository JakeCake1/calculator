using _Project.Scripts.Application.ContainerMediator;
using _Project.Scripts.Application.StateMachine.Interfaces;
using _Project.Scripts.Calculator;
using _Project.Scripts.WarningService;

namespace _Project.Scripts.Application.StateMachine.States
{  
  /// \class ApplicationState
  /// \brief Класс-состояние, отвечающий за основную логику в приложении
  public sealed class ApplicationState : IApplicationState
  {  
    /// \brief Контейнер зависимостей
    private readonly IDependenciesContainer _dependenciesContainer;
    /// \brief Сервис, вызывающий окно с предупреждением
    private IWarningService _warningService;
    /// \brief Логика калькулятора
    private ICalculator _calculator;

    /// \brief Конструктор состояния
    /// \param dependenciesContainer   Контейнер для получения зависимостей
    public ApplicationState(IDependenciesContainer dependenciesContainer) => 
      _dependenciesContainer = dependenciesContainer;

    /// \brief Метод входа в состояние
    public async void Enter()
    {
      _dependenciesContainer.CreateApplicationStateDependencies(out _warningService, out _calculator);

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
      
      _dependenciesContainer.CleanupApplicationStateDependencies();
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
  }
}