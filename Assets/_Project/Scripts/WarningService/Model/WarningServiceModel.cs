using _Project.Scripts.WarningService.View;

namespace _Project.Scripts.WarningService.Model
{
  public class WarningServiceModel : IWarningServiceModel
  {
    private IWarningView _warningView;
    
    private bool _isOpen;

    public void Init(IWarningView warningWindowView) => 
      _warningView = warningWindowView;

    public void SetState(bool isOpen)
    {
      _isOpen = isOpen;
      _warningView.SetState(_isOpen);
    }
  }
}