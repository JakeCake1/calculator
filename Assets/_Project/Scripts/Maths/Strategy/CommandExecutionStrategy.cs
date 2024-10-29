using System;
using _Project.Scripts.Maths.Command;
using _Project.Scripts.Maths.Data;
using _Project.Scripts.Maths.Factory;
using UnityEngine;

namespace _Project.Scripts.Maths.Strategy
{
  public class CommandExecutionStrategy : ICommandExecutionStrategy
  {
    private readonly IAvailableMathCommands _availableMathCommands;
    private readonly IExpressionFactory _expressionFactory;

    public CommandExecutionStrategy(IAvailableMathCommands availableMathCommands, IExpressionFactory expressionFactory)
    {
      _expressionFactory = expressionFactory;
      _availableMathCommands = availableMathCommands;
    }

    public void TrySolveExpression(string expressionString, out MathCommand mathCommand)
    {
      Expression expression = _expressionFactory.CreateExpression(expressionString, _availableMathCommands);

      if (CheckExpressionForValid(expression))
      {
        mathCommand = null;
        return;
      }

      mathCommand = DefineMathCommand(expression);

      if (!ExecuteMathCommand(expression, mathCommand)) 
        mathCommand = null;
    }

    private MathCommand DefineMathCommand(Expression expression)
    {
      if(_availableMathCommands.TryGetValue(expression.Operator, out Type mathOperationType))
      {
        MathCommand command = (MathCommand) Activator.CreateInstance(mathOperationType);
        return command;
      }

      LogExpressionError();
      return null;
    }

    private bool ExecuteMathCommand(Expression expression, MathCommand command)
    {
      if (CheckExpressionForValid(expression))
        return false;

      if (command == null)
      {
        LogExpressionError();
        return false;
      }

      return command.Execute(expression);
    }
    
    private bool CheckExpressionForValid(Expression expression)
    {
      if (!expression.IsValid())
      {
        Debug.LogWarning("Expression is not valid");
        return true;
      }

      return false;
    }

    private void LogExpressionError() => 
      Debug.LogWarning("Math command for expression not found");
  }
}

