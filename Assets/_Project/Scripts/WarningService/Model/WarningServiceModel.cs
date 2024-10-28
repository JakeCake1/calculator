using _Project.Scripts.WarningService.View;

namespace _Project.Scripts.WarningService.Model
{
  public class WarningServiceModel : IWarningServiceModel
  {
    private readonly IWarningView _warningView;
    
    private bool _isOpen;

    public WarningServiceModel(IWarningView warningView) => 
      _warningView = warningView;

    public void SetState(bool isOpen)
    {
      _isOpen = isOpen;
      _warningView.SetState(_isOpen);
    }
  }
}