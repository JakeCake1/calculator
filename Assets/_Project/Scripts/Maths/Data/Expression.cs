namespace _Project.Scripts.Maths.Data
{
  public struct Expression
  {
    public readonly string Operand1;
    public readonly string Operator;
    public readonly string Operand2;

    public Expression(string operand2, string @operator, string operand1)
    {
      Operand2 = operand2;
      Operator = @operator;
      Operand1 = operand1;
    }

    public bool IsValid() => 
      !(string.IsNullOrEmpty(Operand1) || string.IsNullOrEmpty(Operator)  || string.IsNullOrEmpty(Operand2));
  }
}