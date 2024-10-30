using _Project.Scripts.AssetProvider.Scripts;
using _Project.Scripts.UIFactory;
using _Project.Scripts.WarningService.View;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.WarningService.Factories
{
  /// \class WarningUIFactory
  /// \brief Класс, отвечающий за создание объектов UI сервиса окна-предупреждения
  public class WarningUIFactory : UIObjectFactory, IWarningUIFactory
  {
    /// \brief Адресс префаба UI сервиса окна-предупреждения
    private const string WarningWindowViewAddress = "Warning Window View";
    
    /// \brief Объект UI сервиса окна-предупреждения
    private WarningServiceView _warningServiceView;
    
    /// \brief Конструктор фабрики UI
    /// \param assetProvider  Поставщик ресурсов
    public WarningUIFactory(IAssetProvider assetProvider) : base(assetProvider)
    { }

    /// \brief Метод создания объекта UI сервиса окна-предупреждения
    /// \return UniTask который можно подождать до завершения процесса создания объекта
    public async UniTask<IWarningView> CreateWarningWindowView()
    {
      if (_warningServiceView != null)
      {
        Debug.LogWarning("WarningServiceView is already created - return cached instance");
        return _warningServiceView;
      }
      
      _warningServiceView = await CreateUIObject<WarningServiceView>(WarningWindowViewAddress);
      _warningServiceView.gameObject.SetActive(false);
      
      return _warningServiceView;
    }

    /// \brief Метод уничтожения объекта UI сервиса окна-предупреждения
    public void ClearWarningWindowView() => 
      Clean(_warningServiceView, WarningWindowViewAddress);
  }
}