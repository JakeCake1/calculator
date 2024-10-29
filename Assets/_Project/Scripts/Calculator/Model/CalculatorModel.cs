using _Project.Scripts.Calculator.View;
using _Project.Scripts.Maths.Command;
using _Project.Scripts.SaveDataService.Collections;
using _Project.Scripts.SaveDataService.Interfaces;

namespace _Project.Scripts.Calculator.Model
{
  public class CalculatorModel : ICalculatorModel
  {
    private const string CommandsHistoryKey = "CommandsHistory";
    private const string CommandInputKey = "CommandInput";

    private const string SubFileKey = "General";

    private const int HistoryMaxCapacity = 20;
    
    private readonly PersistentStack<string> _history;

    private readonly ISaveDataService _saveDataService;

    private ICalculatorMainView _calculatorMainView;

    private string _inputExpression;

    public CalculatorModel(ISaveDataService saveDataService)
    {
      _saveDataService = saveDataService;

      _history = new PersistentStack<string>(saveDataService);
      _history.SetMaxCapacity(HistoryMaxCapacity);

      _history.Load(SubFileKey, CommandsHistoryKey);
    }

    public void Init(ICalculatorMainView calculatorMainView) => 
      _calculatorMainView = calculatorMainView;

    public void UpdateState()
    {
      _inputExpression = _saveDataService.Get<string>(SubFileKey, CommandInputKey);

      UpdateHistory();
      _calculatorMainView.SetInputExpression(_inputExpression);
    }

    public void AddSolution(MathCommand solution)
    {
      if (solution == null)
        return;

      _history.Push(solution.GetResult());
      UpdateHistory();
    }

    public void AddErrorSolution(string expression)
    {
      _history.Push($"{expression}=Error");
      UpdateHistory();
    }

    public void SetInputExpression(string expression)
    {
      _inputExpression = expression;

      _saveDataService.Save(SubFileKey, CommandInputKey, expression);
      _saveDataService.Write();
    }

    private void UpdateHistory()
    {
      string[] mathCommands = _history.ToArray();
      _calculatorMainView.SetHistory(mathCommands);
    }
  }
}