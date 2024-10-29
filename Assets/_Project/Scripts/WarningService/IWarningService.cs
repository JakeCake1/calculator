using System;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.WarningService
{
  public interface IWarningService
  {
    event Action OnCloseWindow;
    UniTask Initialize();
    void OpenWindow();
    void Quit();
  }
}