using _Project.Scripts.Application.StateMachine.Interfaces;
using _Project.Scripts.Application.StateMachine.States;
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
      builder.Register<IAssetProvider, AssetProvider.Scripts.AssetProvider>(Lifetime.Singleton);

      RegisterSaveService(builder);
      RegisterWarningService(builder);
      RegisterMaths(builder);
      RegisterCalculator(builder);
      RegisterEntryPoint(builder);
    }

    private void RegisterSaveService(IContainerBuilder builder)
    {
      builder.Register<IDataLoader, DataLoader>(Lifetime.Singleton);
      builder.Register<BaseSaveStrategy, SaveToPlayerPrefsImpl>(Lifetime.Singleton);
      builder.Register<ISaveDataService, SaveDataService.SaveDataService>(Lifetime.Singleton);
    }
    
    private void RegisterWarningService(IContainerBuilder builder)
    {
      builder.Register<IWarningServiceModel, WarningServiceModel>(Lifetime.Singleton);
      builder.Register<IWarningServicePresenter, WarningServicePresenter>(Lifetime.Singleton);
      
      builder.Register<IWarningUIFactory, WarningUIFactory>(Lifetime.Singleton);
      builder.Register<IWarningService, WarningServiceLogic>(Lifetime.Singleton);
    }
    
    private void RegisterMaths(IContainerBuilder builder)
    {
      builder.Register<IExpressionFactory, ExpressionFactory>(Lifetime.Singleton);
      builder.Register<IAvailableMathCommands, AvailableMathCommands>(Lifetime.Singleton);
      builder.Register<ICommandExecutionStrategy, CommandExecutionStrategy>(Lifetime.Singleton);
      builder.Register<ICommandValidationWrapper, CommandValidationWrapper>(Lifetime.Singleton);

      builder.Register<IMaths, Maths.Maths>(Lifetime.Singleton);
    }
    
    private void RegisterCalculator(IContainerBuilder builder)
    {
      builder.Register<ICalculatorModel, CalculatorModel>(Lifetime.Singleton);
      builder.Register<ICalculatorPresenter, CalculatorPresenter>(Lifetime.Singleton);
      
      builder.Register<ICalculatorUIFactory, CalculatorUIFactory>(Lifetime.Singleton);
      builder.Register<ICalculator, Calculator.Calculator>(Lifetime.Singleton);
    }

    private void RegisterEntryPoint(IContainerBuilder builder)
    {
      builder.RegisterEntryPoint<Bootstrapper>();
      
      builder.Register<IApplicationStateMachine, ApplicationStateMachine>(Lifetime.Singleton);
      
      builder.Register<ApplicationState>(Lifetime.Singleton);
      builder.Register<StartupState>(Lifetime.Singleton);
    }
  }
}