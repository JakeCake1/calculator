using System;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Calculator
{
  public interface ICalculator
  {
    event Action OnErrorOccurred;
    UniTask Initialize();
    void SetActive(bool isActive);
    void Quit();
  }
}