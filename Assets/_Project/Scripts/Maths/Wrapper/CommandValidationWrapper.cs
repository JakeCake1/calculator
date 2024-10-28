using System.Text.RegularExpressions;
using _Project.Scripts.Maths.Command;
using _Project.Scripts.Maths.Strategy;
using UnityEngine;

namespace _Project.Scripts.Maths.Wrapper
{
  public class CommandValidationWrapper : ICommandValidationWrapper
  {
    private readonly ICommandExecutionStrategy _commandExecutionStrategy;

    public CommandValidationWrapper(ICommandExecutionStrategy commandExecutionStrategy) => 
      _commandExecutionStrategy = commandExecutionStrategy;

    public bool TryExecuteExpression(string expression, out MathCommand command)
    {     
      string pattern = @"^\d+\+\d+$";
        
      bool isValid = Regex.IsMatch(expression, pattern);
        
      if (isValid)
        _commandExecutionStrategy.TrySolveExpression(expression, out command);
      else
      {
        command = null;
        Debug.LogError("Expression form is not valid");
      }

      return command != null;
    }
  }
}