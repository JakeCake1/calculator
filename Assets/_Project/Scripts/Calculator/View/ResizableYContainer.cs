using UnityEngine;

namespace _Project.Scripts.Calculator.View
{
  /// \class ResizableYContainer
  /// \brief Компонент для контроля высоты RectTransform в зависимости от высоты другого объекта
  [RequireComponent(typeof(RectTransform))]
  public class ResizableYContainer : MonoBehaviour
  {
    /// \brief Целевой компонент для подбора высоты
    [SerializeField] private RectTransform _targetTransform;
    /// \brief Максимальная возможная высота RectTransform
    [SerializeField] private float _maximumSizeY;

    /// \brief Компонент RectTransform текущего объекта
    private RectTransform _rectTransform;
    /// \brief Последний полученный размер целеового компонента
    private Vector2 _lastSize;

    /// \brief Метод инициализации и подбора первичной высоты компонента RectTransform
    private void Start()
    {
      _rectTransform = GetComponent<RectTransform>();
      _lastSize = _targetTransform.rect.size;    
      
      _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _lastSize.y > _maximumSizeY ? _maximumSizeY : _lastSize.y);
    }
    
    /// \brief Метод для считывания изменений размера целевого RectTransform
    private void Update()
    {
      Vector2 currentSize = _targetTransform.rect.size;

      if (currentSize != _lastSize)
      {
        OnSizeChanged(currentSize);
        _lastSize = currentSize;
      }
    }
    
    /// \brief Метод для обновления размера RectTransform текущего объекта
    /// \param newSize    Новый размер целевого RectTransform
    private void OnSizeChanged(Vector2 newSize)
    {
      Debug.Log("RectTransform size changed to: " + newSize);
      _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, newSize.y > _maximumSizeY ? _maximumSizeY : newSize.y);
    }
  }
}