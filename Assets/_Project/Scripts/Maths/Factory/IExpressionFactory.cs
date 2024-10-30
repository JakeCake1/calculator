using _Project.Scripts.Maths.Data;

namespace _Project.Scripts.Maths.Factory
{
  /// \interface IExpressionFactory
  /// \brief Интерфейс фабрики, отвечающий за создание математических выражений
  public interface IExpressionFactory
  {
    /// \brief Метод создания математического выражения
    /// \param expressionString   Строка с математическим выражением
    /// \param availableMathCommands   Коллекция доступных математических команд
    /// \return Математическое выражение для выполнения команд над ним
    Expression CreateExpression(string expressionString, IAvailableMathCommands availableMathCommands);
  }
}