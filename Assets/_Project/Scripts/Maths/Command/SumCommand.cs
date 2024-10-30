using _Project.Scripts.Maths.Data;

namespace _Project.Scripts.Maths.Command
{  
  /// \class SumCommand
  /// \brief Класс математической команды сложения
  public class SumCommand : MathCommand
  {    
    /// \brief Метод, опрделяющий ход слолжения
    /// \param expression    Математическое выражение
    /// \param answer    результат вычисления
    /// \return Флаг успешности вычисления
    protected override bool Solve(Expression expression, out string answer)
    {     
      answer = $"{expression.Operand1}+{expression.Operand2}=ERROR";

      if (!int.TryParse(expression.Operand1, out int operand1))
        return false;
      
      if (!int.TryParse(expression.Operand2, out int operand2))
        return false;
      
      answer = $"{operand1}+{operand2}={operand1 + operand2}";
      return true;
    }
  }
}