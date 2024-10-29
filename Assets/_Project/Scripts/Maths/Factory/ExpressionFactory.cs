using System.Text.RegularExpressions;
using _Project.Scripts.Maths.Data;

namespace _Project.Scripts.Maths.Factory
{
  public class ExpressionFactory : IExpressionFactory
  {  
    public Expression CreateExpression(string expressionString, IAvailableMathCommands availableMathCommands)
    {
      string pattern = MakeRegexExpressionPattern(availableMathCommands);

      string[] operands = FindOperandsAndOperator(expressionString, pattern, out string @operator);

      return new Expression(operands[1], @operator, operands[0]);
    }
    
    private string MakeRegexExpressionPattern(IAvailableMathCommands availableMathCommands)
    {
      string operations = "";
      
      foreach (var command in availableMathCommands.GetCommandsKeys()) 
        operations += command;
      
      string pattern = $@"(\d+)|([{operations}])";
      return pattern;
    }

    private string[] FindOperandsAndOperator(string expressionString, string pattern, out string @operator)
    {
      MatchCollection matches = Regex.Matches(expressionString, pattern);

      string[] operands = new string[2];
      int index = 0;
      
      @operator = null;
      
      foreach (Match match in matches)
      {
        if (match.Groups[1].Success)
        {
          operands[index] = match.Groups[1].Value;
          index++;
        }
        else if (match.Groups[2].Success) 
          @operator = match.Groups[2].Value;
      }

      return operands;
    }

  }
}