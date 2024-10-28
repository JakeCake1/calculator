using System;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Calculator
{
  public interface ICalculator
  {
    event Action OnErrorOccurred;
    UniTask Initialize();
    void OpenWindow();
    void Quit();
  }
}