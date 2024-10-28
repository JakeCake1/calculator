using _Project.Scripts.Calculator.View;
using _Project.Scripts.SaveDataService.Collections;
using _Project.Scripts.SaveDataService.Interfaces;

namespace _Project.Scripts.Calculator.Model
{
  public class CalculatorModel : ICalculatorModel
  {
    private readonly ISaveDataService _saveDataService;
    
    private ICalculatorMainView _calculatorMainView;

    private string _inputExpression;
    private readonly PersistentStack<string> _history;

    public CalculatorModel(ISaveDataService saveDataService)
    {
      _saveDataService = saveDataService;
      
      _history = new PersistentStack<string>(saveDataService);
      _history.Load("General", "CommandsHistory");
    }
    
    public void Init(ICalculatorMainView calculatorMainView)
    {
      _calculatorMainView = calculatorMainView;
    }

    public void UpdateState()
    {
      _inputExpression = _saveDataService.GetString("General", "CommandInput");
    }
    
    public void AddSolution(string solution)
    {
      _history.Push(solution);
    }

    public void SetInputExpression(string expression)
    {
      _inputExpression = expression;
      _saveDataService.SaveString("General", "CommandInput",expression);
    }

    public void SetHistory()
    {
      string[] strings = _history.ToArray();
    }
  }
}