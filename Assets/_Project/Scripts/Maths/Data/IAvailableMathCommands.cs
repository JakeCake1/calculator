using System;
using System.Collections.Generic;

namespace _Project.Scripts.Maths.Data
{
  public interface IAvailableMathCommands
  {
    bool TryGetValue(string expressionOperator, out Type type);
    IEnumerable<string> GetCommandsKeys();
  }
}