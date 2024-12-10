using System;
using _Project.Scripts.Calculator.View;

namespace _Project.Scripts.Calculator.Presenter
{ 
  /// \interface ICalculatorPresenter
  /// \brief Интерфейс, описывающий презентер часть калькулятора
  public interface ICalculatorPresenter
  {
    /// \brief Метод инициализации презентера
    /// \param onErrorOccurred    Ивент появления ошибочного решения
    void Init(ICalculatorMainView calculatorMainView, Action onErrorOccurred);
    /// \brief Метод обновления состояния калькулятора
    void UpdateState();
    /// \brief Метод записи выражения в строку ввода View
    /// \param expression    Математическое выражение для строки ввода
    void UpdateInputExpression(string expression);
    /// \brief Метод записи истории математических вычислений в скролл UI
    /// \param history    История математических выражений
    void UpdateHistory(string[] history);
    /// \brief Метод записи из строки ввода
    /// \param expression    Содержимое строки ввода
    void SetInputExpression(string expression);
    /// \brief Метод получения решения математичского выражения
    /// \param expression    Содержимое строки ввода
    void Solve(string expression);
  }
}