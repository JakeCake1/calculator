namespace _Project.Scripts.Application.StateMachine.Interfaces
{
  public interface IApplicationExitableState
  {
    void SetStateMachine(IApplicationStateMachine applicationStateMachine);
    void Exit();
  }

  public interface IApplicationState : IApplicationExitableState
  {
    void Enter();
  }
}