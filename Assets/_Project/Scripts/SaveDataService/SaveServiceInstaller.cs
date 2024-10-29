using _Project.Scripts.SaveDataService.Interfaces;
using _Project.Scripts.SaveDataService.SaveImplementations;
using VContainer;
using VContainer.Unity;

namespace _Project.Scripts.SaveDataService
{
  public class SaveServiceInstaller : IInstaller
  {
    public void Install(IContainerBuilder builder)
    {
      builder.Register<IDataLoader, DataLoader>(Lifetime.Singleton);
      builder.Register<BaseSaveStrategy, SaveToPlayerPrefsImpl>(Lifetime.Singleton);
      builder.Register<ISaveDataService, SaveDataService>(Lifetime.Singleton);
    }
  }
}