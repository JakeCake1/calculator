namespace _Project.Scripts.Maths.Data
{
  /// \struct Expression
  /// \brief Структура математического выражения
  public struct Expression
  {
    /// \brief Первый операнд
    public readonly string Operand1;
    /// \brief Математический оператор
    public readonly string Operator;
    /// \brief Второй операнд
    public readonly string Operand2;

    /// \brief Конструктор выражения
    public Expression(string operand2, string @operator, string operand1)
    {
      Operand2 = operand2;
      Operator = @operator;
      Operand1 = operand1;
    }

    /// \brief Метод проверки структуры математического выражения на валидность
    /// \return Флаг валидности структуры математического выражения
    public bool IsValid() => 
      !(string.IsNullOrEmpty(Operand1) || string.IsNullOrEmpty(Operator)  || string.IsNullOrEmpty(Operand2));
  }
}