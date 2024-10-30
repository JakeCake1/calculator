using System;
using System.Collections.Generic;

namespace _Project.Scripts.Maths.Data
{
  /// \interface IAvailableMathCommands
  /// \brief Интерфейс коллекции доступных математических выражений
  public interface IAvailableMathCommands
  {
    /// \brief Метод получения типа математической операции
    /// \param expressionOperator   Оператор, обозначающий математическую операцию
    /// \param type   Тип математической операции
    /// \return Флаг успешности получения типа математической операции
    bool TryGetValue(string expressionOperator, out Type type);
    /// \brief Метод получения списка доступных символов-операторов
    /// \return Коллекция доступных операторов
    IEnumerable<string> GetCommandsKeys();
  }
}