using _Project.Scripts.AssetProvider.Scripts;
using VContainer;
using VContainer.Unity;

namespace _Project.Scripts.AssetProvider
{  
  /// \class AssetProviderInstaller
  /// \brief Класс отвечающий за инъекцию AssetProvider в приложение
  public class AssetProviderInstaller: IInstaller
  {    
    /// \brief Метод конфигурации зависимостей AssetProvider
    public void Install(IContainerBuilder builder) => 
      builder.Register<IAssetProvider, AssetProvider.Scripts.AssetProvider>(Lifetime.Singleton);
  }
}