using _Project.Scripts.Maths.Command;

namespace _Project.Scripts.Maths
{
  public interface IMaths
  {
    bool TryExecuteExpression(string expression, out MathCommand command);
  }
}