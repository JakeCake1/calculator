using _Project.Scripts.Maths.Data;

namespace _Project.Scripts.Maths.Command
{  
  public class SumCommand : MathCommand
  {
    protected override bool Solve(Expression expression, out string answer)
    {     
      answer = $"{expression.Operand1}+{expression.Operand2}=Error";

      if (!int.TryParse(expression.Operand1, out int operand1))
        return false;
      
      if (!int.TryParse(expression.Operand2, out int operand2))
        return false;
      
      answer = $"{operand1}+{operand2}={operand1 + operand2}";
      return true;
    }
  }
}