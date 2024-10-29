using _Project.Scripts.Calculator.View;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Calculator.Factories
{
  public interface ICalculatorUIFactory
  {
    UniTask<ICalculatorMainView> CreateCalculatorMainView();
    void ClearCalculatorMainView();
  }
}