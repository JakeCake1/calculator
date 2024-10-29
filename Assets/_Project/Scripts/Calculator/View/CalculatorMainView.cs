using System.Collections.Generic;
using _Project.Scripts.Calculator.Presenter;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Calculator.View
{
  public class CalculatorMainView : MonoBehaviour, ICalculatorMainView
  {
    private ICalculatorPresenter _calculatorPresenter;
    
    [SerializeField] private TMP_Text _historyText;
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private Button _resultButton;

    public void Init(ICalculatorPresenter calculatorPresenter)
    {
      _calculatorPresenter = calculatorPresenter;
      Initialize();
    }

    public void SetState(bool isOpen) =>
      gameObject.SetActive(isOpen);

    public void SetInputExpression(string expression) => 
      _inputField.SetTextWithoutNotify(expression);

    public void SetHistory(string[] history)
    {
      string text = "";
      
      foreach (string command in history) 
        text += command + "\n";

      _historyText.text = text;
    }
    
    private void Initialize()
    {
      _inputField.onValueChanged.AddListener(OnInputValueChanged);
      _resultButton.onClick.AddListener(OnResultClicked);
    }

    private void OnInputValueChanged(string value) => 
      _calculatorPresenter.SetInputExpression(value);

    private void OnResultClicked() => 
      _calculatorPresenter.Solve(_inputField.text);
  }
}