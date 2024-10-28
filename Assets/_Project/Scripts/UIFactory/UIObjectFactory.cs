using _Project.Scripts.AssetProvider.Scripts;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.UIFactory
{
  public abstract class UIObjectFactory
  {
    private readonly IAssetProvider _assetProvider;

    protected UIObjectFactory(IAssetProvider assetProvider) =>
      _assetProvider = assetProvider;

    protected async UniTask<T> CreateUIObject<T>(string address, Transform parent = null)
    {
      var gameObject = await _assetProvider.Load<GameObject>(address);
      T obj = Object.Instantiate(gameObject, parent).GetComponent<T>();

      return obj;
    }

    protected void Clean(Component component, string address = null)
    {
      if (component != null)
        Object.Destroy(component.gameObject);

      if (address != null)
        _assetProvider.Release(address);
    }
  }
}