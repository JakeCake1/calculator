using _Project.Scripts.Maths.Command;

namespace _Project.Scripts.Maths.Strategy
{
  public interface ICommandExecutionStrategy
  {
    void TrySolveExpression(string expressionString, out MathCommand mathCommand);
  }
}