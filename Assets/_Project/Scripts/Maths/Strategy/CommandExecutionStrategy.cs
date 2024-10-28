using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using _Project.Scripts.Maths.Command;
using _Project.Scripts.Maths.Data;
using UnityEngine;

namespace _Project.Scripts.Maths.Strategy
{
  public class CommandExecutionStrategy : ICommandExecutionStrategy
  {
    private readonly Dictionary<string, Type> _availableCommands = new()
    {
      {"+", typeof(SumCommand)}
    };

    public void TrySolveExpression(string expressionString, out MathCommand mathCommand)
    {
      Expression expression = SeparateExpressionByOperators(expressionString);

      if (CheckExpressionForValid(expression))
      {
        mathCommand = null;
        return;
      }

      mathCommand = DefineMathCommand(expression);
      
      ExecuteMathCommand(expression, mathCommand);
    }

    private Expression SeparateExpressionByOperators(string expressionString)
    {
      string operations = "";
      
      foreach (var command in _availableCommands) 
        operations += command.Key;
      
      string pattern = $@"(\d+)|([{operations}])";
      
      MatchCollection matches = Regex.Matches(expressionString, pattern);

      string operand1 = null;
      string operand2 = null;
      string @operator = null;
      
      foreach (Match match in matches)
      {
        if (match.Groups[1].Success)
        {
          if (!string.IsNullOrEmpty(operand1) && !string.IsNullOrEmpty(operand1))
          {
            Debug.LogError("More than 2 operands in expression");
            return new Expression();
          }

          if(operand1 == null)
            operand1 = match.Groups[1].Value;
          
          if(operand2 == null)
            operand2 = match.Groups[1].Value;
        }
        else if (match.Groups[2].Success) 
          @operator = match.Groups[2].Value;
      }

      return new Expression(operand1, @operator, operand2);
    }

    private MathCommand DefineMathCommand(Expression expression)
    {
      if(_availableCommands.TryGetValue(expression.Operator, out Type mathOperationType))
      {
        MathCommand command = (MathCommand) Activator.CreateInstance(mathOperationType);
        return command;
      }

      Debug.LogError("Math command for expression not found");
      return null;
    }

    private void ExecuteMathCommand(Expression expression, MathCommand command)
    {
      if (CheckExpressionForValid(expression))
        return;

      if (command == null)
      {
        Debug.LogError("Math command for expression not found");
        return;
      }
      
      command.Execute(expression);
    }

    private bool CheckExpressionForValid(Expression expression)
    {
      if (!expression.IsValid())
      {
        Debug.LogError("Expression is not valid");
        return true;
      }

      return false;
    }
  }
}

