using _Project.Scripts.AssetProvider.Scripts;
using _Project.Scripts.UIFactory;
using _Project.Scripts.WarningService.View;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.WarningService.Factories
{
  public class WarningUIFactory : UIObjectFactory, IWarningUIFactory
  {
    private const string WarningWindowViewAddress = "Warning Window View";
    
    private WarningServiceView _warningServiceView;
    
    public WarningUIFactory(IAssetProvider assetProvider) : base(assetProvider)
    { }

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

    public void ClearWarningWindowView() => 
      Clean(_warningServiceView, WarningWindowViewAddress);
  }
}