using _Project.Scripts.Maths.Command;

namespace _Project.Scripts.Maths.Wrapper
{
  public interface ICommandValidationWrapper
  {
    bool TryExecuteExpression(string expression, out MathCommand command);
  }
}