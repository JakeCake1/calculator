using _Project.Scripts.AssetProvider.Scripts;
using _Project.Scripts.Calculator.View;
using _Project.Scripts.UIFactory;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Calculator.Factories
{
  public sealed class CalculatorUIFactory : UIObjectFactory, ICalculatorUIFactory
  {
    private const string CalculatorMainViewAddress = "Calculator Main View";
    
    private CalculatorMainView _calculatorMainView;
    
    public CalculatorUIFactory(IAssetProvider assetProvider) : base(assetProvider)
    { }

    public async UniTask<ICalculatorMainView> CreateCalculatorMainView()
    {
      if (_calculatorMainView != null)
      {
        Debug.LogWarning("CalculatorMainView is already created - return cached instance");
        return _calculatorMainView;
      }
      
      _calculatorMainView = await CreateUIObject<CalculatorMainView>(CalculatorMainViewAddress);
      _calculatorMainView.gameObject.SetActive(false);
      
      return _calculatorMainView;
    }

    public void ClearCalculatorMainView() => 
      Clean(_calculatorMainView, CalculatorMainViewAddress);
  }
}