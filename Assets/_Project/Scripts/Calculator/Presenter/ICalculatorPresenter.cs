using System;

namespace _Project.Scripts.Calculator.Presenter
{ 
  /// \interface ICalculatorPresenter
  /// \brief Интерфейс, описывающий презентер часть калькулятора
  public interface ICalculatorPresenter
  {
    /// \brief Метод инициализации презентера
    /// \param onErrorOccurred    Ивент появления ошибочного решения
    void Init(Action onErrorOccurred);
    /// \brief Метод обновления состояния калькулятора
    void UpdateState();
    /// \brief Метод записи из строки ввода
    /// \param expression    Содержимое строки ввода
    void SetInputExpression(string expression);
    /// \brief Метод получения решения математичского выражения
    /// \param expression    Содержимое строки ввода
    void Solve(string expression);
  }
}