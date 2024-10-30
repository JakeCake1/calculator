using _Project.Scripts.Maths.Data;

namespace _Project.Scripts.Maths.Command
{
  /// \class MathCommand
  /// \brief Базовый класс математической команды
  public abstract class MathCommand
  {
    /// \brief Результат вычисления
    private string _result;

    /// \brief Метод получения результата вычисления
    /// \return Результат вычисления
    public string GetResult() => 
      _result;
    
    /// \brief Метод выполнения вычисления
    /// \param expression    Математическое выражение
    /// \return Флаг успешности вычисления
    public bool Execute(Expression expression)
    {
      bool solveIsSuccessful = Solve(expression, out string result);
      _result = result;

      return solveIsSuccessful;
    }
    
    /// \brief Метод, опрделяющий ход вычисления
    /// \param expression    Математическое выражение
    /// \param answer    результат вычисления
    /// \return Флаг успешности вычисления
    protected abstract bool Solve(Expression expression, out string answer);
  }
}