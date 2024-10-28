using Cysharp.Threading.Tasks;

namespace _Project.Scripts.WarningService
{
  public interface IWarningService
  {
    UniTask Initialize();
    void OpenWindow();
    void Quit();
  }
}