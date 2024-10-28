using _Project.Scripts.WarningService.Presenter;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

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

    private void Initialize() => 
      _okButton.onClick.AddListener(OnOkClicked);

    public void SetState(bool isOpen) => 
      gameObject.SetActive(isOpen);

    private void OnOkClicked() => 
      _warningServicePresenter.SetState(false);
  }
}