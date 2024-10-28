using System.Collections.Generic;
using _Project.Scripts.Calculator.View;
using _Project.Scripts.SaveDataService.Collections;

namespace _Project.Scripts.Calculator.Model
{
  public class CalculatorModel : ICalculatorModel
  {
    private ICalculatorMainView _calculatorMainView;

    private string _inputExpression;
    private PersistentStack<string> _history;
    
    public void Init(ICalculatorMainView calculatorMainView)
    {
      _calculatorMainView = calculatorMainView;
    }

    public void UpdateState()
    {
      
    }
    
    public void AddSolution(string solution)
    {
      
    }

    public void SetInputExpression(string expression)
    {
      
    }

    public void SetHistory(Stack<string> history)
    {
      
    }
  }
}