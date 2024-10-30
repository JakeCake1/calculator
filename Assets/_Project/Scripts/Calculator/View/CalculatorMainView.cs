using _Project.Scripts.Calculator.Presenter;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Calculator.View
{
  /// \class CalculatorMainView
  /// \brief Класс, описывающий вид калькулятора
  public class CalculatorMainView : MonoBehaviour, ICalculatorMainView
  { 
    /// \brief Презентер калькулятора
    private ICalculatorPresenter _calculatorPresenter;
    
    /// \brief Текст-компонент истории математических операций
    [SerializeField] private TMP_Text _historyText;
    /// \brief Текст-компонент ввода выражения
    [SerializeField] private TMP_InputField _inputField;
    /// \brief Кнопка-компонент вывода результата вычисления
    [SerializeField] private Button _resultButton;
  
    /// \brief Метод инициализации вида калькулятора
    /// \param calculatorPresenter    Презентер компонент калькулятора
    public void Init(ICalculatorPresenter calculatorPresenter)
    {
      _calculatorPresenter = calculatorPresenter;
      Initialize();
    }
    
    /// \brief Метод активации/скрытия вида калькулятора
    /// \param isOpen    Параметр true/false. Если true - вид отображается, false - вид скрыт
    public void SetState(bool isOpen) =>
      gameObject.SetActive(isOpen);
    
    /// \brief Метод записи выражения в строку ввода
    /// \param expression    Математическое выражение для строки ввода
    public void SetInputExpression(string expression) => 
      _inputField.SetTextWithoutNotify(expression);
    
    /// \brief Метод записи истории математических вычислений в скролл UI
    /// \param history    История математических выражений
    public void SetHistory(string[] history)
    {
      string text = "";
      
      foreach (string command in history) 
        text += command + "\n";

      _historyText.text = text;
    }
    
    /// \brief Инициализация пользовательского ввода в UI
    private void Initialize()
    {
      _inputField.onValueChanged.AddListener(OnInputValueChanged);
      _resultButton.onClick.AddListener(OnResultClicked);
    }
    
    /// \brief Метод, отлавливающий изменения данных при вводе в строку
    /// \param value  Новое выражение, полученное из ввода
    private void OnInputValueChanged(string value) => 
      _calculatorPresenter.SetInputExpression(value);
    
    /// \brief Метод, отправляющий выражение в решение при нажатии на кнопку Result
    private void OnResultClicked() => 
      _calculatorPresenter.Solve(_inputField.text);
  }
}