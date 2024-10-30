using _Project.Scripts.WarningService.Presenter;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.WarningService.View
{  
  /// \interface WarningServiceView
  /// \brief Класс, описывающий вид сервиса окна-предупреждения
  public class WarningServiceView : MonoBehaviour, IWarningView
  {
    /// \brief Презентер сервиса окна-предупреждения
    private IWarningServicePresenter _warningServicePresenter;

    /// \brief Кнопка-компонент для закрытия окна-предупреждения
    [SerializeField] private Button _okButton;
    
    /// \brief Метод инициализации вида сервиса окна-предупреждения
    /// \param calculatorPresenter    Презентер компонент сервиса окна-предупреждения
    public void Init(IWarningServicePresenter warningServicePresenter)
    {
      _warningServicePresenter = warningServicePresenter;
      Initialize();
    }
    
    /// \brief Метод изменения состояния окна-предупреждения
    /// \param isOpen    true - окно открыто, false - окно закрыто
    public void SetState(bool isOpen) => 
      gameObject.SetActive(isOpen);

    /// \brief Метод инициализации вида окна-предупреждения
    private void Initialize() => 
      _okButton.onClick.AddListener(OnOkClicked);
    
    /// \brief Метод, обрабатывающий клик по кнопке закрытия окна
    private void OnOkClicked() => 
      _warningServicePresenter.SetState(false);
  }
}