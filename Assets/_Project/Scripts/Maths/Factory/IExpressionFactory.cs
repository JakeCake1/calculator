using _Project.Scripts.Maths.Data;

namespace _Project.Scripts.Maths.Factory
{
  public interface IExpressionFactory
  {
    Expression CreateExpression(string expressionString, IAvailableMathCommands availableMathCommands);
  }
}