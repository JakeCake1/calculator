using _Project.Scripts.Maths.Command;
using _Project.Scripts.Maths.Wrapper;

namespace _Project.Scripts.Maths
{
  public class Maths : IMaths
  {
    private readonly ICommandValidationWrapper _commandValidationWrapper;

    public Maths(ICommandValidationWrapper commandValidationWrapper) => 
      _commandValidationWrapper = commandValidationWrapper;

    public bool TryExecuteExpression(string expression, out MathCommand command) => 
      _commandValidationWrapper.TryExecuteExpression(expression, out command);
  }
}