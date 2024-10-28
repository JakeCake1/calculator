using _Project.Scripts.Calculator.View;

namespace _Project.Scripts.Calculator.Model
{
  public class CalculatorModel : ICalculatorModel
  {
    private ICalculatorMainView _calculatorMainView;

    public void Init(ICalculatorMainView calculatorMainView)
    {
      _calculatorMainView = calculatorMainView;
    }
  }
}