using _Project.Scripts.Calculator.Model;

namespace _Project.Scripts.Calculator.Presenter
{
  public class CalculatorPresenter : ICalculatorPresenter
  {
    private ICalculatorModel _calculatorModel;

    public CalculatorPresenter(ICalculatorModel calculatorModel)
    {
      _calculatorModel = calculatorModel;
    }

    public void UpdateState()
    {
      
    }
    
    public void SetInputExpression(string expression)
    {
      
    }

    public string Solve(string expression)
    {
      return "";
    }
  }
}