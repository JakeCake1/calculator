using System;
using System.Collections.Generic;
using _Project.Scripts.Maths.Command;

namespace _Project.Scripts.Maths.Data
{
  /// \class AvailableMathCommands
  /// \brief Класс-коллекция доступных математических команд
  public class AvailableMathCommands : IAvailableMathCommands
  {
    /// \brief Коллекция доступных математических команд
    private readonly Dictionary<string, Type> _availableCommands = new()
    {
      {"+", typeof(SumCommand)}
    };

    /// \brief Метод получения типа математической операции
    /// \param expressionOperator   Оператор, обозначающий математическую операцию
    /// \param type   Тип математической операции
    /// \return Флаг успешности получения типа математической операции
    public bool TryGetValue(string expressionOperator, out Type type) => 
      _availableCommands.TryGetValue(expressionOperator, out type);

    /// \brief Метод получения списка доступных символов-операторов
    /// \return Коллекция доступных операторов
    public IEnumerable<string> GetCommandsKeys() => 
      _availableCommands.Keys;
  }
}