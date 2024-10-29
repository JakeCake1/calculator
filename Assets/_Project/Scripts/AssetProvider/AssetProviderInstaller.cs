using _Project.Scripts.AssetProvider.Scripts;
using VContainer;
using VContainer.Unity;

namespace _Project.Scripts.AssetProvider
{
  public class AssetProviderInstaller: IInstaller
  {
    public void Install(IContainerBuilder builder) => 
      builder.Register<IAssetProvider, AssetProvider.Scripts.AssetProvider>(Lifetime.Singleton);
  }
}