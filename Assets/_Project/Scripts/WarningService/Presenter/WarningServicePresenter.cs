using _Project.Scripts.WarningService.Model;

namespace _Project.Scripts.WarningService.Presenter
{
  public class WarningServicePresenter : IWarningServicePresenter
  {
    private readonly IWarningServiceModel _warningServiceModel;

    public WarningServicePresenter(IWarningServiceModel warningServiceModel) => 
      _warningServiceModel = warningServiceModel;

    public void SetState(bool isOpen) => 
      _warningServiceModel.SetState(isOpen);
  }
}