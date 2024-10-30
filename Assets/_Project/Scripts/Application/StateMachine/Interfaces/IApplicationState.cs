namespace _Project.Scripts.Application.StateMachine.Interfaces
{
  /// \interface IApplicationState
  /// \brief Интерфейс, описывающий основное состояние приложения
  public interface IApplicationExitableState
  {
    /// \brief Метод выхода из состояния
    void Exit();
  }
  
  /// \interface IApplicationState
  /// \brief Интерфейс, описывающий вход в состояние приложения
  public interface IApplicationState : IApplicationExitableState
  {
    /// \brief Метод входа в состояние
    void Enter();
  }
}