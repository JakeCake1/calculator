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
    
    private IWarningView _warningWindowView;

    public WarningServiceLogic(IWarningUIFactory warningUIFactory)
    {
      _warningUIFactory = warningUIFactory;
    }
    
    public async UniTask Initialize()
    {
      _warningWindowView = await _warningUIFactory.CreateWarningWindowView();

      var warningServiceModel = new WarningServiceModel(_warningWindowView);
      var warningServicePresenter = new WarningServicePresenter(warningServiceModel);

      _warningWindowView.Construct(warningServicePresenter);
    }

    public void OpenWindow()
    {
      _warningWindowView.SetState(true);
    }

    public void Quit()
    {
      _warningUIFactory.ClearWarningWindowView();
    }
  }
}