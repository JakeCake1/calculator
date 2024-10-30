using _Project.Scripts.AssetProvider.Scripts;
using _Project.Scripts.Calculator.View;
using _Project.Scripts.UIFactory;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Calculator.Factories
{
  /// \class CalculatorUIFactory
  /// \brief Класс, отвечающий за создание объектов UI калькулятора
  public sealed class CalculatorUIFactory : UIObjectFactory, ICalculatorUIFactory
  {
    /// \brief Адресс префаба UI калькулятора
    private const string CalculatorMainViewAddress = "Calculator Main View";
    
    /// \brief Объект UI калькулятора
    private CalculatorMainView _calculatorMainView;
    
    /// \brief Конструктор фабрики UI
    /// \param assetProvider  Поставщик ресурсов
    public CalculatorUIFactory(IAssetProvider assetProvider) : base(assetProvider)
    { }
    
    /// \brief Метод создания объекта UI калькулятора
    /// \return UniTask который можно подождать до завершения процесса создания объекта
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
    
    /// \brief Метод уничтожения объекта UI калькулятора
    public void ClearCalculatorMainView() => 
      Clean(_calculatorMainView, CalculatorMainViewAddress);
  }
}