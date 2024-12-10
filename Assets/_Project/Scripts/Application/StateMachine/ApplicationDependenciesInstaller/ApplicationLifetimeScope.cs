using _Project.Scripts.Application.ContainerMediator;
using _Project.Scripts.Application.StateMachine.Interfaces;
using _Project.Scripts.Application.StateMachine.States;
using _Project.Scripts.AssetProvider;
using _Project.Scripts.SaveDataService;
using VContainer;
using VContainer.Unity;

namespace _Project.Scripts.Application.StateMachine.ApplicationDependenciesInstaller
{
  /// \class ApplicationLifetimeScope
  /// \brief Класс, отвечающий за инъекцию сервисов в приложении
  public sealed class ApplicationLifetimeScope : LifetimeScope
  {  
    /// \brief Метод конфигурации зависимостей сервисов
    protected override void Configure(IContainerBuilder builder)
    {
      builder.Register<IDependenciesContainer, DependenciesContainer>(Lifetime.Singleton);
      
      new AssetProviderInstaller().Install(builder);
      new SaveServiceInstaller().Install(builder);
      
      RegisterEntryPoint(builder);
    }

    /// \brief Метод регистрации точки входа и основных состояний приложения
    private void RegisterEntryPoint(IContainerBuilder builder)
    {
      builder.RegisterEntryPoint<Bootstrapper>();
      
      builder.Register<IApplicationStateMachine, ApplicationStateMachine>(Lifetime.Singleton);
      
      builder.Register<ApplicationState>(Lifetime.Singleton);
      builder.Register<StartupState>(Lifetime.Singleton);
    }
  }
}