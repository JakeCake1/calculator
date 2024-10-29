using _Project.Scripts.WarningService.Presenter;

namespace _Project.Scripts.WarningService.View
{
  public interface IWarningView
  {
    void Init(IWarningServicePresenter warningServicePresenter);
    void SetState(bool isOpen);
  }
}