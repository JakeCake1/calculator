using _Project.Scripts.Calculator.Presenter;

namespace _Project.Scripts.Calculator.View
{
  public interface ICalculatorMainView
  {
    void Init(ICalculatorPresenter calculatorPresenter);
    void SetState(bool isOpen);
    void SetInputExpression(string expression);
    void SetHistory(string[] history);
  }
}