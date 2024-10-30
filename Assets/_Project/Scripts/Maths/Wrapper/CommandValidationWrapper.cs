using System.Text.RegularExpressions;
using _Project.Scripts.Maths.Command;
using _Project.Scripts.Maths.Data;
using _Project.Scripts.Maths.Strategy;
using UnityEngine;

namespace _Project.Scripts.Maths.Wrapper
{  
  /// \interface CommandValidationWrapper
  /// \brief Класс, отвечающий за первичную проверку введенных выражений на корректность 
  public class CommandValidationWrapper : ICommandValidationWrapper
  {
    /// \brief Объект, выполняющий вычисление по алгоритму
    private readonly ICommandExecutionStrategy _commandExecutionStrategy;
    /// \brief  Коллекция доступных математических команд
    private readonly IAvailableMathCommands _availableMathCommands;

    /// \brief Конструктор обертки проверки
    /// \param commandExecutionStrategy   Объект, выполняющий вычисление по алгоритму
    /// \param availableMathCommands   Коллекция доступных математических команд
    public CommandValidationWrapper(ICommandExecutionStrategy commandExecutionStrategy, IAvailableMathCommands availableMathCommands)
    {
      _availableMathCommands = availableMathCommands;
      _commandExecutionStrategy = commandExecutionStrategy;
    }

    /// \brief Метод запуска математических вычислений
    /// \param expression   Строка с математическим выражением
    /// \param command   Математическая команда, сгенерированная в ходе вычислений
    /// \return Флаг успешности вычисления: true - вычисление произошло успешно, false - произошла ошибка
    public bool TryExecuteExpression(string expression, out MathCommand command)
    {     
      string operations = "";
      
      foreach (var @operator in _availableMathCommands.GetCommandsKeys()) 
        operations += @operator;
      
      string pattern = $@"^\d+[{operations}]\d+$"; //Паттерн, согласно которому проверяется форма выражения [Операнд1]+[Операнд2]
      
      bool isValid = Regex.IsMatch(expression, pattern);
        
      if (isValid)
        _commandExecutionStrategy.TrySolveExpression(expression, out command);
      else
      {
        command = null;
        Debug.LogWarning("Expression form is not valid");
      }

      return command != null;
    }
  }
}