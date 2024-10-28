using System;
using _Project.Scripts.Calculator.Model;
using _Project.Scripts.Maths;
using _Project.Scripts.Maths.Command;

namespace _Project.Scripts.Calculator.Presenter
{
  public class CalculatorPresenter : ICalculatorPresenter
  {
    private readonly ICalculatorModel _calculatorModel;
    private readonly IMaths _maths;
    
    private Action _onErrorOccurred;

    public CalculatorPresenter(ICalculatorModel calculatorModel, IMaths maths)
    {
      _maths = maths;
      _calculatorModel = calculatorModel;
    }

    public void Init(Action onErrorOccurred) => 
      _onErrorOccurred = onErrorOccurred;

    public void UpdateState() => 
      _calculatorModel.UpdateState();

    public void SetInputExpression(string expression) => 
      _calculatorModel.SetInputExpression(expression);

    public void Solve(string expression)
    {
      if(_maths.TryExecuteExpression(expression, out MathCommand mathCommand))
        _calculatorModel.AddSolution(mathCommand);
      else
        _onErrorOccurred?.Invoke();
    }
  }
}