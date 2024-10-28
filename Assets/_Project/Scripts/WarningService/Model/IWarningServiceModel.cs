using _Project.Scripts.WarningService.View;

namespace _Project.Scripts.WarningService.Model
{
  public interface IWarningServiceModel
  {
    void Init(IWarningView warningWindowView);
    void SetState(bool isOpen);
  }
}