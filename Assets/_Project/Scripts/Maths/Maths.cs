using _Project.Scripts.Maths.Command;
using _Project.Scripts.Maths.Wrapper;

namespace _Project.Scripts.Maths
{
  /// \class Maths
  /// \brief Класс, отвечающий за взаимодействие с логикой математических вычислений
  public class Maths : IMaths
  {
    /// \brief commandValidationWrapper   Обертка, выполняющая проверку выражения на корректность
    private readonly ICommandValidationWrapper _commandValidationWrapper;

    /// \brief Конструктор логики математических вычислений
    /// \param commandValidationWrapper   Обертка, выполняющая проверку выражения на корректность
    public Maths(ICommandValidationWrapper commandValidationWrapper) => 
      _commandValidationWrapper = commandValidationWrapper;
    
    /// \brief Метод запуска математических вычислений
    /// \param expression   Строка с математическим выражением
    /// \param command   Математическая команда, сгенерированная в ходе вычислений
    /// \return Флаг успешности вычисления: true - вычисление произошло успешно, false - произошла ошибка
    public bool TryExecuteExpression(string expression, out MathCommand command) => 
      _commandValidationWrapper.TryExecuteExpression(expression, out command);
  }
}