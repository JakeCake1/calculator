using _Project.Scripts.Maths.Command;

namespace _Project.Scripts.Maths.Strategy
{
  /// \interface ICommandExecutionStrategy
  /// \brief Интерфейс, отвечающий за выполнение математических операций
  public interface ICommandExecutionStrategy
  {
    /// \brief Метод запуска математических вычислений
    /// \param expressionString   Строка с математическим выражением
    /// \param mathCommand   Математическая команда, сгенерированная в ходе вычислений
    void TrySolveExpression(string expressionString, out MathCommand mathCommand);
  }
}