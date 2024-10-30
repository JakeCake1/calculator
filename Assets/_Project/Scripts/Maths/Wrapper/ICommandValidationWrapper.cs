using _Project.Scripts.Maths.Command;

namespace _Project.Scripts.Maths.Wrapper
{
  /// \interface ICommandValidationWrapper
  /// \brief Интерфейс, отвечающий за проверку введенных выражений на корректность 
  public interface ICommandValidationWrapper
  {
    /// \brief Метод запуска математических вычислений
    /// \param expression   Строка с математическим выражением
    /// \param command   Математическая команда, сгенерированная в ходе вычислений
    /// \return Флаг успешности вычисления: true - вычисление произошло успешно, false - произошла ошибка
    bool TryExecuteExpression(string expression, out MathCommand command);
  }
}