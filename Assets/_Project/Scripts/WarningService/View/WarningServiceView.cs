using UnityEngine;

namespace _Project.Scripts.WarningService.View
{
  public class WarningServiceView : MonoBehaviour, IWarningView
  {
    public void SetState(bool isOpen)
    {
      gameObject.SetActive(isOpen);
    }
  }
}