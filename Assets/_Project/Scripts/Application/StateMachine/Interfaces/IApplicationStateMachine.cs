namespace _Project.Scripts.Application.StateMachine.Interfaces
{
  public interface IApplicationStateMachine
  {
    void Enter<TState>() where TState : class, IApplicationState;
  }
}