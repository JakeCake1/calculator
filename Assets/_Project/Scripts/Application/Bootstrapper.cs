using _Project.Scripts.Application.StateMachine.Interfaces;
using _Project.Scripts.Application.StateMachine.States;
using UnityEngine;
using VContainer;

namespace _Project.Scripts.Application
{
  public sealed class Bootstrapper : MonoBehaviour
  {
    private IApplicationStateMachine _applicationStateMachine;

    [Inject]
    public void Construct(IApplicationStateMachine applicationStateMachine) =>
      _applicationStateMachine = applicationStateMachine;

    private void Start() => 
      _applicationStateMachine.Enter<StartupState>();
  }
}