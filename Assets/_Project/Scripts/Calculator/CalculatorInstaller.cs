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
      builder.Register<ICalculatorModel, CalculatorModel>(Lifetime.Singleton);
      builder.Register<ICalculatorPresenter, CalculatorPresenter>(Lifetime.Singleton);
      
      builder.Register<ICalculatorUIFactory, CalculatorUIFactory>(Lifetime.Singleton);
      builder.Register<ICalculator, Calculator>(Lifetime.Singleton);
    }
  }
}