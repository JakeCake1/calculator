using _Project.Scripts.SaveDataService.Interfaces;
using _Project.Scripts.SaveDataService.SaveImplementations;
using VContainer;
using VContainer.Unity;

namespace _Project.Scripts.SaveDataService.Installer
{
  public sealed class SaveDataServiceDependencyInstaller : LifetimeScope
  {
    protected override void Configure(IContainerBuilder builder)
    {    
      builder.Register<ISaveDataService, SaveDataService>(Lifetime.Singleton);
      builder.Register<BaseSaveStrategy, SaveToPlayerPrefsImpl>(Lifetime.Singleton);
      builder.Register<IDataLoader, DataLoader>(Lifetime.Singleton);
    }
  }
}