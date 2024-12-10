using System;
using _Project.Scripts.Calculator.Model;
using _Project.Scripts.Calculator.View;
using _Project.Scripts.Maths;
using _Project.Scripts.Maths.Command;

namespace _Project.Scripts.Calculator.Presenter
{  
  /// \class CalculatorPresenter
  /// \brief Класс, описывающий презентер часть калькулятора
  public class CalculatorPresenter : ICalculatorPresenter
  {
    /// \brief Модель калькулятора
    private readonly ICalculatorModel _calculatorModel;  
    /// \brief View калькулятора
    private ICalculatorMainView _calculatorMainView;
    /// \brief Математическа логика
    private readonly IMaths _maths;
    /// \brief Ивент появления ошибки при вычислениях
    private Action _onErrorOccurred;

    /// \brief Конструктор презентера
    /// \param calculatorModel   Модель калькулятора
    /// \param maths   Математическа логика
    public CalculatorPresenter(ICalculatorModel calculatorModel, IMaths maths)
    {
      _maths = maths;
      _calculatorModel = calculatorModel;
    }
    
    /// \brief Метод инициализации презентера
    /// \param calculatorMainView View калькулятора
    /// \param onErrorOccurred    Ивент появления ошибочного решения
    public void Init(ICalculatorMainView calculatorMainView, Action onErrorOccurred)
    {
      _calculatorMainView = calculatorMainView;
      _onErrorOccurred = onErrorOccurred;
    }

    /// \brief Метод обновления состояния калькулятора
    public void UpdateState() => 
      _calculatorModel.UpdateState();
    
    /// \brief Метод записи выражения в строку ввода View
    /// \param expression    Математическое выражение для строки ввода
    public void UpdateInputExpression(string expression) => 
      _calculatorMainView.SetInputExpression(expression);
    
    /// \brief Метод записи истории математических вычислений в скролл UI
    /// \param history    История математических выражений
    public void UpdateHistory(string[] history) => 
      _calculatorMainView.SetHistory(history);

    /// \brief Метод записи из строки ввода
    /// \param expression    Содержимое строки ввода
    public void SetInputExpression(string expression) => 
      _calculatorModel.SetInputExpression(expression);
    
    /// \brief Метод получения решения математичского выражения
    /// \param expression    Содержимое строки ввода
    public void Solve(string expression)
    {
      if(_maths.TryExecuteExpression(expression, out MathCommand mathCommand))
        _calculatorModel.AddSolution(mathCommand);
      else
      {
        _calculatorModel.AddErrorSolution(expression);
        _onErrorOccurred?.Invoke();
      }
    }
  }
}