using System;
using System.Text.RegularExpressions;
using _Project.Scripts.Maths.Command;
using _Project.Scripts.Maths.Data;
using UnityEngine;

namespace _Project.Scripts.Maths.Strategy
{
  public class CommandExecutionStrategy : ICommandExecutionStrategy
  {
    private readonly IAvailableMathCommands _availableMathCommands;

    public CommandExecutionStrategy(IAvailableMathCommands availableMathCommands) => 
      _availableMathCommands = availableMathCommands;

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
      
      foreach (var command in _availableMathCommands.GetCommandsKeys()) 
        operations += command;
      
      string pattern = $@"(\d+)|([{operations}])";
      
      MatchCollection matches = Regex.Matches(expressionString, pattern);

      string[] operands = new string[2];
      int index = 0;
      
      string @operator = null;
      
      foreach (Match match in matches)
      {
        if (match.Groups[1].Success)
        {
          if (index >= operands.Length)
          {
            Debug.LogError("More than 2 operands in expression");
            return new Expression();
          }

          operands[index] = match.Groups[1].Value;
          index++;
        }
        else if (match.Groups[2].Success) 
          @operator = match.Groups[2].Value;
      }

      return new Expression(operands[1], @operator, operands[0]);
    }

    private MathCommand DefineMathCommand(Expression expression)
    {
      if(_availableMathCommands.TryGetValue(expression.Operator, out Type mathOperationType))
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

