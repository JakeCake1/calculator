using System;
using _Project.Scripts.Maths.Command;
using _Project.Scripts.Maths.Data;
using _Project.Scripts.Maths.Factory;
using UnityEngine;

namespace _Project.Scripts.Maths.Strategy
{
  /// \class CommandExecutionStrategy
  /// \brief Класс, отвечающий за выполнение математических операций
  public class CommandExecutionStrategy : ICommandExecutionStrategy
  {
    /// \brief Коллекция доступных математических операций
    private readonly IAvailableMathCommands _availableMathCommands;
    /// \brief Фабрика создания объектов выражений
    private readonly IExpressionFactory _expressionFactory;
    
    /// \brief Конструктор логики математических вычислений
    /// \param availableMathCommands  Коллекция доступных математических операций
    /// \param expressionFactory  Фабрика создания объектов выражений
    public CommandExecutionStrategy(IAvailableMathCommands availableMathCommands, IExpressionFactory expressionFactory)
    {
      _expressionFactory = expressionFactory;
      _availableMathCommands = availableMathCommands;
    }
    
    /// \brief Метод запуска математических вычислений
    /// \param expressionString   Строка с математическим выражением
    /// \param mathCommand   Математическая команда, сгенерированная в ходе вычислений
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
    
    /// \brief Метод создания математичесой команды для введнного выражения 
    /// \param expression   Структура выражения
    /// \return mathCommand   Математическая команда, сгенерированная в ходе подбора подходящей команды для вычисления выражения
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
    
    /// \brief Метод выполнения математичесой команды
    /// \param expression   Структура выражения
    /// \param command   Математическая команда, сгенерированная в ходе подбора подходящей команды для вычисления выражения
    /// \return Флаг успешности вычисления: true - вычисление произошло успешно, false - произошла ошибка
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
    
    /// \brief Метод проверки математического выражения на правильный состав
    /// \param expression   Структура выражения
    /// \return Флаг валидности выражения: true - выражение имеет форму [Операнд1]+[Операнд2], false - форма не соответствует
    private bool CheckExpressionForValid(Expression expression)
    {
      if (!expression.IsValid())
      {
        Debug.LogWarning("Expression is not valid");
        return true;
      }

      return false;
    }

    /// \brief Метод логирования ошибки в ходе вычислений
    private void LogExpressionError() => 
      Debug.LogWarning("Math command for expression not found");
  }
}

