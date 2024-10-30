using _Project.Scripts.Calculator.View;
using _Project.Scripts.Maths.Command;

namespace _Project.Scripts.Calculator.Model
{
  /// \interface ICalculatorModel
  /// \brief Интерфейс, описывающий модель данных и состояния калькулятора
  public interface ICalculatorModel
  {
    /// \brief Метод инициализации модели
    /// \param calculatorMainView    View компонент калькулятора
    void Init(ICalculatorMainView calculatorMainView);
    /// \brief Метод обновления UI калькулятора
    void UpdateState();
    /// \brief Метод добавления решения в историю
    /// \param solution    Объект выполненной математической команды
    void AddSolution(MathCommand solution);
    /// \brief Метод добавления ошибочного решения в историю
    /// \param expression    Результат попытки выполнить математичскую операцию
    void AddErrorSolution(string expression);
    /// \brief Метод записи в модель данных из строки ввода
    /// \param expression    Содержимое строки ввода
    void SetInputExpression(string expression);
  }
}