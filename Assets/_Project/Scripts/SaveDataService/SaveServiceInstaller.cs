using _Project.Scripts.SaveDataService.Interfaces;
using _Project.Scripts.SaveDataService.SaveImplementations;
using VContainer;
using VContainer.Unity;

namespace _Project.Scripts.SaveDataService
{  
  /// \class SaveServiceInstaller
  /// \brief Класс отвечающий за инъекцию SaveDataService в приложение
  public class SaveServiceInstaller : IInstaller
  {
    /// \brief Метод конфигурации зависимостей SaveDataService
    public void Install(IContainerBuilder builder)
    {
      builder.Register<IDataLoader, DataLoader>(Lifetime.Singleton);
      builder.Register<BaseSaveStrategy, SaveToPlayerPrefsImpl>(Lifetime.Singleton);
      builder.Register<ISaveDataService, SaveDataService>(Lifetime.Singleton);
    }
  }
}