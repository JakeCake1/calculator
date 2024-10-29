using _Project.Scripts.Calculator.Factories;
using _Project.Scripts.Calculator.Model;
using _Project.Scripts.Calculator.Presenter;
using VContainer;
using VContainer.Unity;

namespace _Project.Scripts.Calculator
{
  public class CalculatorInstaller : IInstaller
  {
    public void Install(IContainerBuilder builder)
    {
      builder.Register<ICalculatorModel, CalculatorModel>(Lifetime.Scoped);
      builder.Register<ICalculatorPresenter, CalculatorPresenter>(Lifetime.Scoped);
      
      builder.Register<ICalculatorUIFactory, CalculatorUIFactory>(Lifetime.Scoped);
      builder.Register<ICalculator, Calculator>(Lifetime.Scoped);
    }
  }
}