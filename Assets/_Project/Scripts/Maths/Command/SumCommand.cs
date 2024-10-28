using _Project.Scripts.Maths.Data;

namespace _Project.Scripts.Maths.Command
{
  public class SumCommand : MathCommand
  {
    protected override string Solve(Expression expression)
    {
      int operand1 = int.Parse(expression.Operand1);
      int operand2 = int.Parse(expression.Operand2);

      return $"{operand1} + {operand2} = {operand1 + operand2}";
    }
  }
}