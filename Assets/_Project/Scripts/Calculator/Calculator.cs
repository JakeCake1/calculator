using System;
using _Project.Scripts.Calculator.Factories;
using _Project.Scripts.Calculator.Model;
using _Project.Scripts.Calculator.Presenter;
using _Project.Scripts.Calculator.View;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Calculator
{
  /// \interface ICalculator
  /// \brief Класс, отвечающий за взаимодействие с логикой калькулятора
  public class Calculator : ICalculator
  {
    /// \brief Фабрика для создания UI калькулятора
    private readonly ICalculatorUIFactory _calculatorUIFactory;

    /// \brief Презентер калькулятора
    private readonly ICalculatorPresenter _calculatorPresenter;
    /// \brief Модель данных калькулятора
    private readonly ICalculatorModel _calculatorModel;
    
    /// \brief UI калькулятора
    private ICalculatorMainView _calculatorMainView;
    
    /// \brief Ивент появления ошибки в вычислениях
    public event Action OnErrorOccurred;
    
    /// \brief Конструктор логики калькулятора
    /// \param calculatorUIFactory   Фабрика для создания UI калькулятора
    /// \param calculatorPresenter   Презентер калькулятора
    /// \param calculatorModel   Модель данных калькулятора
    public Calculator(ICalculatorUIFactory calculatorUIFactory, 
      ICalculatorPresenter calculatorPresenter, ICalculatorModel calculatorModel)
    {
      _calculatorModel = calculatorModel;
      _calculatorPresenter = calculatorPresenter;
      _calculatorUIFactory = calculatorUIFactory;
    }
    
    /// \brief Метод инициализации логики калькулятора
    /// \return UniTask который можно подождать до завершения процесса инициализации
    public async UniTask Initialize()
    {
      _calculatorMainView = await _calculatorUIFactory.CreateCalculatorMainView();
      _calculatorModel.Init(_calculatorPresenter);
      _calculatorMainView.Init(_calculatorPresenter);
      
      _calculatorPresenter.Init(_calculatorMainView, OnErrorOccurred);
      _calculatorPresenter.UpdateState();
    }
    
    /// \brief Метод активации/скрытия вида калькулятора
    /// \param isActive    Параметр true/false. Если true - вид отображается, false - вид скрыт
    public void SetActive(bool isActive) => 
      _calculatorMainView.SetState(isActive);

    /// \brief Метод завершения и очистки логики калькулятора
    public void Quit() => 
      _calculatorUIFactory.ClearCalculatorMainView();
  }
}