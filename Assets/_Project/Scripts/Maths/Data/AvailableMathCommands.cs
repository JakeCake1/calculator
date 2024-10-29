using System;
using System.Collections.Generic;
using _Project.Scripts.Maths.Command;

namespace _Project.Scripts.Maths.Data
{
  public class AvailableMathCommands : IAvailableMathCommands
  {
    private readonly Dictionary<string, Type> _availableCommands = new()
    {
      {"+", typeof(SumCommand)}
    };

    public bool TryGetValue(string expressionOperator, out Type type) => 
      _availableCommands.TryGetValue(expressionOperator, out type);

    public IEnumerable<string> GetCommandsKeys() => 
      _availableCommands.Keys;
  }
}