using _Project.Scripts.Application.StateMachine.Interfaces;
using _Project.Scripts.Application.StateMachine.States;
using _Project.Scripts.AssetProvider;
using _Project.Scripts.AssetProvider.Scripts;
using _Project.Scripts.Calculator;
using _Project.Scripts.Calculator.Factories;
using _Project.Scripts.Calculator.Model;
using _Project.Scripts.Calculator.Presenter;
using _Project.Scripts.Maths;
using _Project.Scripts.Maths.Data;
using _Project.Scripts.Maths.Factory;
using _Project.Scripts.Maths.Strategy;
using _Project.Scripts.Maths.Wrapper;
using _Project.Scripts.SaveDataService;
using _Project.Scripts.SaveDataService.Interfaces;
using _Project.Scripts.SaveDataService.SaveImplementations;
using _Project.Scripts.WarningService;
using _Project.Scripts.WarningService.Factories;
using _Project.Scripts.WarningService.Model;
using _Project.Scripts.WarningService.Presenter;
using VContainer;
using VContainer.Unity;

namespace _Project.Scripts.Application.StateMachine.ApplicationDependenciesInstaller
{
  public sealed class ApplicationLifetimeScope : LifetimeScope
  {
    protected override void Configure(IContainerBuilder builder)
    {    
      new AssetProviderInstaller().Install(builder);
      new SaveServiceInstaller().Install(builder);
      new WarningServiceInstaller().Install(builder);
      new MathsInstaller().Install(builder);
      new CalculatorInstaller().Install(builder);
      
      RegisterEntryPoint(builder);
    }

    private void RegisterEntryPoint(IContainerBuilder builder)
    {
      builder.RegisterEntryPoint<Bootstrapper>();
      
      builder.Register<IApplicationStateMachine, ApplicationStateMachine>(Lifetime.Singleton);
      
      builder.Register<ApplicationState>(Lifetime.Singleton);
      builder.Register<StartupState>(Lifetime.Singleton);
      builder.Register<EmptyState>(Lifetime.Singleton);
    }
  }
}