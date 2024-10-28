using _Project.Scripts.WarningService.Presenter;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.WarningService.View
{
  public class WarningServiceView : MonoBehaviour, IWarningView
  {
    private IWarningServicePresenter _warningServicePresenter;

    [SerializeField] private Button _okButton;
    
    public void Init(IWarningServicePresenter warningServicePresenter)
    {
      _warningServicePresenter = warningServicePresenter;
      Initialize();
    }

    public void SetState(bool isOpen) => 
      gameObject.SetActive(isOpen);

    private void Initialize() => 
      _okButton.onClick.AddListener(OnOkClicked);

    private void OnOkClicked() => 
      _warningServicePresenter.SetState(false);
  }
}