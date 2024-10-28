using _Project.Scripts.WarningService.Factories;
using _Project.Scripts.WarningService.Model;
using _Project.Scripts.WarningService.Presenter;
using _Project.Scripts.WarningService.View;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.WarningService
{
  public class WarningServiceLogic : IWarningService
  {
    private readonly IWarningUIFactory _warningUIFactory;

    private readonly IWarningServicePresenter _warningServicePresenter;
    private readonly IWarningServiceModel _warningServiceModel;
    
    private IWarningView _warningWindowView;

    public WarningServiceLogic(IWarningUIFactory warningUIFactory, 
      IWarningServicePresenter warningServicePresenter, IWarningServiceModel warningServiceModel)
    {
      _warningServiceModel = warningServiceModel;
      _warningServicePresenter = warningServicePresenter;
      _warningUIFactory = warningUIFactory;
    }
    
    public async UniTask Initialize()
    {
      _warningWindowView = await _warningUIFactory.CreateWarningWindowView();
      
      _warningServiceModel.Init(_warningWindowView);
      _warningWindowView.Init(_warningServicePresenter);
    }

    public void OpenWindow() => 
      _warningWindowView.SetState(true);

    public void Quit() => 
      _warningUIFactory.ClearWarningWindowView();
  }
}