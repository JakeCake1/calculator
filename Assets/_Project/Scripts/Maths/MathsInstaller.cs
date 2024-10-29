using _Project.Scripts.Maths.Data;
using _Project.Scripts.Maths.Factory;
using _Project.Scripts.Maths.Strategy;
using _Project.Scripts.Maths.Wrapper;
using VContainer;
using VContainer.Unity;

namespace _Project.Scripts.Maths
{
  public class MathsInstaller : IInstaller
  {
    public void Install(IContainerBuilder builder)
    {
      builder.Register<IExpressionFactory, ExpressionFactory>(Lifetime.Singleton);
      builder.Register<IAvailableMathCommands, AvailableMathCommands>(Lifetime.Singleton);
      builder.Register<ICommandExecutionStrategy, CommandExecutionStrategy>(Lifetime.Singleton);
      builder.Register<ICommandValidationWrapper, CommandValidationWrapper>(Lifetime.Singleton);

      builder.Register<IMaths, Maths>(Lifetime.Singleton);
    }
  }
}