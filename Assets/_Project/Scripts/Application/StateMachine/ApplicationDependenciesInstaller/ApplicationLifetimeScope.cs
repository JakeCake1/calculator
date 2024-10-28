using _Project.Scripts.Application.StateMachine.Interfaces;
using _Project.Scripts.Application.StateMachine.States;
using _Project.Scripts.AssetProvider.Scripts;
using _Project.Scripts.SaveDataService;
using _Project.Scripts.SaveDataService.Interfaces;
using _Project.Scripts.SaveDataService.SaveImplementations;
using _Project.Scripts.WarningService;
using _Project.Scripts.WarningService.Factories;
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
      builder.Register<IWarningUIFactory, WarningUIFactory>(Lifetime.Singleton);
      builder.Register<IWarningService, WarningServiceLogic>(Lifetime.Singleton);
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