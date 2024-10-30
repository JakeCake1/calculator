using _Project.Scripts.Calculator.Factories;
using _Project.Scripts.Calculator.Model;
using _Project.Scripts.Calculator.Presenter;
using VContainer;
using VContainer.Unity;

namespace _Project.Scripts.Calculator
{
  /// \class CalculatorInstaller
  /// \brief Класс, отвечающий за инъекцию логики калькулятора в приложение
  public class CalculatorInstaller : IInstaller
  {
    /// \brief Метод конфигурации зависимостей логики калькулятора
    public void Install(IContainerBuilder builder)
    {
      builder.Register<ICalculatorModel, CalculatorModel>(Lifetime.Scoped);
      builder.Register<ICalculatorPresenter, CalculatorPresenter>(Lifetime.Scoped);
      
      builder.Register<ICalculatorUIFactory, CalculatorUIFactory>(Lifetime.Scoped);
      builder.Register<ICalculator, Calculator>(Lifetime.Scoped);
    }
  }
}