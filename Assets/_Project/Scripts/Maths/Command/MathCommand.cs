using _Project.Scripts.Maths.Data;

namespace _Project.Scripts.Maths.Command
{
  public abstract class MathCommand
  {
    private string _result;

    public string GetResult() => 
      _result;

    public bool Execute(Expression expression)
    {
      bool solveIsSuccessful = Solve(expression, out string result);
      _result = result;

      return solveIsSuccessful;
    }

    protected abstract bool Solve(Expression expression, out string answer);
  }
}