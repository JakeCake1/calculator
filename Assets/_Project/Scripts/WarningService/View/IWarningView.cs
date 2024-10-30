using _Project.Scripts.WarningService.Presenter;

namespace _Project.Scripts.WarningService.View
{
  /// \interface IWarningView
  /// \brief Интерфейс, описывающий вид сервиса окна-предупреждения
  public interface IWarningView
  {
    /// \brief Метод инициализации вида сервиса окна-предупреждения
    /// \param calculatorPresenter    Презентер компонент сервиса окна-предупреждения
    void Init(IWarningServicePresenter warningServicePresenter);
    /// \brief Метод изменения состояния окна-предупреждения
    /// \param isOpen    true - окно открыто, false - окно закрыто
    void SetState(bool isOpen);
  }
}


