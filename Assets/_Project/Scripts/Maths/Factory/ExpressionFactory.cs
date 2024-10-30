using System.Text.RegularExpressions;
using _Project.Scripts.Maths.Data;

namespace _Project.Scripts.Maths.Factory
{
  /// \class ExpressionFactory
  /// \brief Класс, отвечающий за создание математических выражений
  public class ExpressionFactory : IExpressionFactory
  {      
    /// \brief Метод создания математического выражения
    /// \param expressionString   Строка с математическим выражением
    /// \param availableMathCommands   Коллекция доступных математических команд
    /// \return Математическое выражение для выполнения команд над ним
    public Expression CreateExpression(string expressionString, IAvailableMathCommands availableMathCommands)
    {
      string pattern = MakeRegexExpressionPattern(availableMathCommands);

      string[] operands = FindOperandsAndOperator(expressionString, pattern, out string @operator);

      return new Expression(operands[1], @operator, operands[0]);
    }
    
    /// \brief Метод создания паттерна для подбора нужной математической команды
    /// \param availableMathCommands   Коллекция доступных математических команд
    /// \return Паттерн для подбора операндов и знака операций, связанных с математической командой
    private string MakeRegexExpressionPattern(IAvailableMathCommands availableMathCommands)
    {
      string operations = "";
      
      foreach (var command in availableMathCommands.GetCommandsKeys()) 
        operations += command;

      return $@"(\d+)|([{operations}])";
    }

    /// \brief Метод поиска элементов математического выражения по паттерну
    /// \param expressionString   Строка с математическим выражением
    /// \param pattern   Паттерн для подбора операндов и знака операций, связанных с математической командой
    /// \param @operator   Знак оператора для составления математического выражения 
    /// \return Операнды для составления математического выражения 
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