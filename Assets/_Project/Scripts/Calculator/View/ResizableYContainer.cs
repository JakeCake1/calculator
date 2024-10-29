using UnityEngine;

namespace _Project.Scripts.Calculator.View
{
  [RequireComponent(typeof(RectTransform))]
  public class ResizableYContainer : MonoBehaviour
  {
    [SerializeField] private RectTransform _targetTransform;
    [SerializeField] private float _maximumSizeY;

    private RectTransform _rectTransform;
    private Vector2 _lastSize;

    private void Start()
    {
      _rectTransform = GetComponent<RectTransform>();
      _lastSize = _targetTransform.rect.size;    
      
      _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _lastSize.y > _maximumSizeY ? _maximumSizeY : _lastSize.y);
    }

    void Update()
    {
      Vector2 currentSize = _targetTransform.rect.size;

      if (currentSize != _lastSize)
      {
        OnSizeChanged(currentSize);
        _lastSize = currentSize;
      }
    }

    private void OnSizeChanged(Vector2 newSize)
    {
      Debug.Log("RectTransform size changed to: " + newSize);
      _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, newSize.y > _maximumSizeY ? _maximumSizeY : newSize.y);
    }
  }
}