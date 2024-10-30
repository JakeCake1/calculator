using System;
using _Project.Scripts.WarningService.View;

namespace _Project.Scripts.WarningService.Model
{
  /// \interface IWarningServiceModel
  /// \brief Интерфейс, описывающий модель данных и состояния сервиса окна-предупреждения
  public interface IWarningServiceModel
  {
    /// \brief Метод инициализации модели
    /// \param calculatorMainView    View компонент сервиса окна-предупреждения
    void Init(IWarningView warningWindowView, Action onCloseWindow);
    /// \brief Метод изменения состояния окна-предупреждения
    /// \param isOpen    true - окно открыто, false - окно закрыто
    void SetState(bool isOpen);
  }
}