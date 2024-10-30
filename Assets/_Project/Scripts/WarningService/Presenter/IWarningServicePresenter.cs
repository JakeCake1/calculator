namespace _Project.Scripts.WarningService.Presenter
{
  /// \interface IWarningServicePresenter
  /// \brief Интерфейс, описывающий презентер сервиса окна-предупреждения
  public interface IWarningServicePresenter
  {
    /// \brief Метод изменения состояния окна-предупреждения
    /// \param isOpen    true - окно открыто, false - окно закрыто
    void SetState(bool isOpen);
  }
}