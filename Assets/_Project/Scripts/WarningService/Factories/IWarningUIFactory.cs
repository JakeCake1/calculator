using _Project.Scripts.WarningService.View;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.WarningService.Factories
{
  public interface IWarningUIFactory
  {
    UniTask<IWarningView> CreateWarningWindowView();
    void ClearWarningWindowView();
  }
}