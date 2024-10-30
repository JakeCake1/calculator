using _Project.Scripts.Maths.Data;
using _Project.Scripts.Maths.Factory;
using _Project.Scripts.Maths.Strategy;
using _Project.Scripts.Maths.Wrapper;
using VContainer;
using VContainer.Unity;

namespace _Project.Scripts.Maths
{
  /// \class MathsInstaller
  /// \brief Класс, отвечающий за инъекцию логики математических вычислений в приложение
  public class MathsInstaller : IInstaller
  {  
    /// \brief Метод конфигурации зависимостей логики математических вычислений
    public void Install(IContainerBuilder builder)
    {
      builder.Register<IExpressionFactory, ExpressionFactory>(Lifetime.Scoped);
      builder.Register<IAvailableMathCommands, AvailableMathCommands>(Lifetime.Scoped);
      builder.Register<ICommandExecutionStrategy, CommandExecutionStrategy>(Lifetime.Scoped);
      builder.Register<ICommandValidationWrapper, CommandValidationWrapper>(Lifetime.Scoped);

      builder.Register<IMaths, Maths>(Lifetime.Scoped);
    }
  }
}