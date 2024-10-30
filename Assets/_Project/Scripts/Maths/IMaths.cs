using _Project.Scripts.Maths.Command;

namespace _Project.Scripts.Maths
{  
  /// \interface IMaths
  /// \brief Интерфейс, отвечающий за взаимодействие с логикой математических вычислений
  public interface IMaths
  {
    /// \brief Метод запуска математических вычислений
    /// \param expression   Строка с математическим выражением
    /// \param command   Математическая команда, сгенерированная в ходе вычислений
    /// \return Флаг успешности вычисления: true - вычисление произошло успешно, false - произошла ошибка
    bool TryExecuteExpression(string expression, out MathCommand command);
  }
}