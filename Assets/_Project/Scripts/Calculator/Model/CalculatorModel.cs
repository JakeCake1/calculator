using _Project.Scripts.Calculator.View;
using _Project.Scripts.Maths.Command;
using _Project.Scripts.SaveDataService.Collections;
using _Project.Scripts.SaveDataService.Interfaces;

namespace _Project.Scripts.Calculator.Model
{  
  /// \class CalculatorModel
  /// \brief Класс, описывающий модель данных и состояния калькулятора
  public class CalculatorModel : ICalculatorModel
  {
    /// \brief Ключ для записи истории решений
    private const string CommandsHistoryKey = "CommandsHistory";
    /// \brief Ключ для записи строки ввода
    private const string CommandInputKey = "CommandInput";
    /// \brief Ключ для записи данных в отдельный файл
    private const string SubFileKey = "General";
    /// \brief Ограничение на количество решений в истории
    private const int HistoryMaxCapacity = 20;
    
    /// \brief Стек решений, сохраняющийся между сессиями
    private readonly PersistentStack<string> _history;
    
    /// \brief Сервис для сохранения данных между сессиями
    private readonly ISaveDataService _saveDataService;
    
    /// \brief View объект UI калькулятора
    private ICalculatorMainView _calculatorMainView;
    /// \brief Выражение введенное в строку ввода
    private string _inputExpression;
    
    /// \brief Конструктор модели
    /// \param saveDataService   Сервис для сохранения данных между сессиями
    public CalculatorModel(ISaveDataService saveDataService)
    {
      _saveDataService = saveDataService;

      _history = new PersistentStack<string>(saveDataService);
      _history.SetMaxCapacity(HistoryMaxCapacity);

      _history.Load(SubFileKey, CommandsHistoryKey);
    }
    
    /// \brief Метод инициализации модели
    /// \param calculatorMainView    View компонент калькулятора
    public void Init(ICalculatorMainView calculatorMainView) => 
      _calculatorMainView = calculatorMainView;
    
    /// \brief Метод обновления UI калькулятора
    public void UpdateState()
    {
      _inputExpression = _saveDataService.Get<string>(SubFileKey, CommandInputKey);

      UpdateHistory();
      _calculatorMainView.SetInputExpression(_inputExpression);
    }
    
    /// \brief Метод добавления решения в историю
    /// \param solution    Объект выполненной математической команды
    public void AddSolution(MathCommand solution)
    {
      if (solution == null)
        return;

      _history.Push(solution.GetResult());
      UpdateHistory();
    }
    
    /// \brief Метод добавления ошибочного решения в историю
    /// \param expression    Результат попытки выполнить математичскую операцию
    public void AddErrorSolution(string expression)
    {
      _history.Push($"{expression}=ERROR");
      UpdateHistory();
    }
    
    /// \brief Метод записи в модель данных из строки ввода
    /// \param expression    Содержимое строки ввода
    public void SetInputExpression(string expression)
    {
      _inputExpression = expression;

      _saveDataService.Save(SubFileKey, CommandInputKey, expression);
      _saveDataService.Write();
    }
    
    /// \brief Метод обновления истории калькулятора
    private void UpdateHistory()
    {
      string[] mathCommands = _history.ToArray();
      _calculatorMainView.SetHistory(mathCommands);
    }
  }
}