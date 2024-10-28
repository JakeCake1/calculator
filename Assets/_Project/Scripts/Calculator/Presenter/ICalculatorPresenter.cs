using System;

namespace _Project.Scripts.Calculator.Presenter
{
  public interface ICalculatorPresenter
  {
    void Init(Action onErrorOccurred);
    void UpdateState();
    void SetInputExpression(string expression);
    void Solve(string expression);
  }
}