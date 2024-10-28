using _Project.Scripts.Calculator.View;
using _Project.Scripts.Maths.Command;

namespace _Project.Scripts.Calculator.Model
{
  public interface ICalculatorModel
  {
    void Init(ICalculatorMainView calculatorMainView);
    void UpdateState();
    void AddSolution(MathCommand solution);
    void SetInputExpression(string expression);
  }
}