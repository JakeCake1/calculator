using _Project.Scripts.Calculator.Presenter;

namespace _Project.Scripts.Calculator.View
{  
  /// \interface ICalculatorMainView
  /// \brief Интерфейс, описывающий вид калькулятора
  public interface ICalculatorMainView
  {  
    /// \brief Метод инициализации вида калькулятора
    /// \param calculatorPresenter    Презентер компонент калькулятора
    void Init(ICalculatorPresenter calculatorPresenter);
    /// \brief Метод активации/скрытия вида калькулятора
    /// \param isOpen    Параметр true/false. Если true - вид отображается, false - вид скрыт
    void SetState(bool isOpen);
    /// \brief Метод записи выражения в строку ввода
    /// \param expression    Математическое выражение для строки ввода
    void SetInputExpression(string expression);
    /// \brief Метод записи истории математических вычислений в скролл UI
    /// \param history    История математических выражений
    void SetHistory(string[] history);
  }
}