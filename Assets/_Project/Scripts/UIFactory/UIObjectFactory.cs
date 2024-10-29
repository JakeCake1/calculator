using System.Collections.Generic;
using _Project.Scripts.AssetProvider.Scripts;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.UIFactory
{
  public abstract class UIObjectFactory
  {
    private readonly IAssetProvider _assetProvider;
    private readonly Dictionary<string, int> _cachedObjects = new();
    
    protected UIObjectFactory(IAssetProvider assetProvider) =>
      _assetProvider = assetProvider;

    protected async UniTask<T> CreateUIObject<T>(string address, Transform parent = null)
    {     
      if (_cachedObjects.ContainsKey(address) && _cachedObjects[address] == -1)
      {
        Debug.LogError("WarningServiceView is in creation process now");
        return default;
      }

      _cachedObjects[address] = -1;
      
      var gameObject = await _assetProvider.Load<GameObject>(address);
      T obj = Object.Instantiate(gameObject, parent).GetComponent<T>();

      _cachedObjects[address] = obj.GetHashCode();
      
      return obj;
    }

    protected void Clean(Component component, string address = null)
    {
      if (component == null)
      {     
        Debug.LogWarning("Component is already null");
        return;
      }
      
      if (component != null)
        Object.Destroy(component.gameObject);

      if (address != null)
      {
        _cachedObjects.Remove(address);
        _assetProvider.Release(address);
      }
    }
  }
}