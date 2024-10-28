using _Project.Scripts.Maths.Data;

namespace _Project.Scripts.Maths.Command
{
  public abstract class MathCommand
  {
    private string _result;

    public string GetResult() => 
      _result;

    public void Execute(Expression expression) => 
      _result = Solve(expression);

    protected abstract string Solve(Expression expression);
  }
}