using _Project.Scripts.Calculator.Presenter;
using UnityEngine;

namespace _Project.Scripts.Calculator.View
{
  public class CalculatorMainView : MonoBehaviour, ICalculatorMainView
  {
    private ICalculatorPresenter _calculatorPresenter;

    public void Init(ICalculatorPresenter calculatorPresenter) => 
      _calculatorPresenter = calculatorPresenter;

    public void SetState(bool isOpen) => 
      gameObject.SetActive(isOpen);
  }
}