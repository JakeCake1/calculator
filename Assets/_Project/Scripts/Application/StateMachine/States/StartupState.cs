using _Project.Scripts.Application.StateMachine.Interfaces;
using _Project.Scripts.SaveDataService.Interfaces;

namespace _Project.Scripts.Application.StateMachine.States
{  
  /// \class StartupState
  /// \brief Класс-состояние, используемый для инициализации сервисов приложения
  public sealed class StartupState : IApplicationState
  {
    /// \brief Сервис, отвечающий за сохранение данных приложения между сессиями
    private readonly ISaveDataService _saveDataService;
    /// \brief Машина состояний, отвечающая за переключение между состояниями приложения
    private readonly IApplicationStateMachine _applicationStateMachine;
    
    /// \brief Конструктор состояния
    /// \param saveDataService   Сервис, отвечающий за сохранение данных приложения между сессиями
    /// \param applicationStateMachine   Машина состояний, отвечающая за переключение между состояниями приложения
    public StartupState(ISaveDataService saveDataService, IApplicationStateMachine applicationStateMachine)
    {
      _saveDataService = saveDataService;
      _applicationStateMachine = applicationStateMachine;
    }
    
    /// \brief Метод входа в состояние
    public void Enter()
    {
      _saveDataService.Load();
      _applicationStateMachine.Enter<ApplicationState>();
    }
    
    /// \brief Метод выхода из состояния
    public void Exit()
    { }
  }
}