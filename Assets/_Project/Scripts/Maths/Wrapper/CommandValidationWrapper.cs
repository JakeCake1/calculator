using _Project.Scripts.Maths.Command;
using _Project.Scripts.Maths.Strategy;

namespace _Project.Scripts.Maths.Wrapper
{
  public class CommandValidationWrapper : ICommandValidationWrapper
  {
    private readonly ICommandExecutionStrategy _commandExecutionStrategy;

    public CommandValidationWrapper(ICommandExecutionStrategy commandExecutionStrategy) => 
      _commandExecutionStrategy = commandExecutionStrategy;

    public bool TryExecuteExpression(string expression, out MathCommand command)
    {
      _commandExecutionStrategy.TrySolveExpression(expression, out command);
      return command != null;
    }
  }
}