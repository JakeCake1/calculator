using System;
using _Project.Scripts.WarningService.View;

namespace _Project.Scripts.WarningService.Model
{
  /// \class WarningServiceModel
  /// \brief Класс, описывающий модель данных и состояния сервиса окна-предупреждения
  public class WarningServiceModel : IWarningServiceModel
  {
    /// \brief View объект UI сервиса окна-предупреждения
    private IWarningView _warningView;
    /// \brief Ивент закрытия окна
    private Action _onCloseWindow;
    /// \brief Флаг состояния окна
    private bool _isOpen;

    /// \brief Метод инициализации модели
    /// \param calculatorMainView    View компонент сервиса окна-предупреждения
    public void Init(IWarningView warningWindowView, Action onCloseWindow)
    {
      _onCloseWindow = onCloseWindow;
      _warningView = warningWindowView;
    }

    /// \brief Метод изменения состояния окна-предупреждения
    /// \param isOpen    true - окно открыто, false - окно закрыто
    public void SetState(bool isOpen)
    {
      _isOpen = isOpen;
      _warningView.SetState(_isOpen);
      
      if(!isOpen)
        _onCloseWindow?.Invoke();
    }
  }
}