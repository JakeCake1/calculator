using System;
using _Project.Scripts.Calculator.Factories;
using _Project.Scripts.Calculator.Model;
using _Project.Scripts.Calculator.Presenter;
using _Project.Scripts.Calculator.View;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Calculator
{
  public class Calculator : ICalculator
  {
    private readonly ICalculatorUIFactory _calculatorUIFactory;

    private readonly ICalculatorPresenter _calculatorPresenter;
    private readonly ICalculatorModel _calculatorModel;
    
    private ICalculatorMainView _calculatorMainView;

    public event Action OnErrorOccurred;

    public Calculator(ICalculatorUIFactory calculatorUIFactory, 
      ICalculatorPresenter calculatorPresenter, ICalculatorModel calculatorModel)
    {
      _calculatorModel = calculatorModel;
      _calculatorPresenter = calculatorPresenter;
      _calculatorUIFactory = calculatorUIFactory;
    }

    public async UniTask Initialize()
    {
      _calculatorMainView = await _calculatorUIFactory.CreateCalculatorMainView();
      _calculatorModel.Init(_calculatorMainView);
      _calculatorMainView.Init(_calculatorPresenter);
      
      _calculatorPresenter.Init(OnErrorOccurred);
      _calculatorPresenter.UpdateState();
    }

    public void SetActive(bool isActive) => 
      _calculatorMainView.SetState(isActive);

    public void Quit() => 
      _calculatorUIFactory.ClearCalculatorMainView();
  }
}