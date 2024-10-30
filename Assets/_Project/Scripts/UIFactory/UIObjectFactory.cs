using System.Collections.Generic;
using _Project.Scripts.AssetProvider.Scripts;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.UIFactory
{
  /// \class UIObjectFactory
  /// \brief Универсальный класс-фабрика для создания UI объектов
  public abstract class UIObjectFactory
  {
    /// \brief Поставщик ресурсов
    private readonly IAssetProvider _assetProvider;
    /// \brief Коллекция идентификаторов созданных объектов
    private readonly Dictionary<string, int> _cachedObjects = new();
    
    /// \brief Конструктор фабрики
    /// \param assetProvider    Поставщик ресурсов
    protected UIObjectFactory(IAssetProvider assetProvider) =>
      _assetProvider = assetProvider;

    /// \brief Метод создания объекта, где Т - класс создаваемого объекта, переданный параметрически
    /// \param address    Адрес создаваемого объекта
    /// \param parent    Родительский объект, в который будет помещен новый объект
    /// \return UniTask который можно подождать до завершения процесса создания объекта
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
    
    /// \brief Метод уничтожения объекта
    /// \param address    Адрес уничтожаемого объекта
    /// \param component    Компонент, объект которого будет уничтожен
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