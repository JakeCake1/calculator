using _Project.Scripts.WarningService.Model;

namespace _Project.Scripts.WarningService.Presenter
{
  /// \class WarningServicePresenter
  /// \brief Класс, описывающий презентер сервиса окна-предупреждения
  public class WarningServicePresenter : IWarningServicePresenter
  {
    /// \brief Модель данных сервиса окна-предупреждения
    private readonly IWarningServiceModel _warningServiceModel;

    /// \brief Конструктор презентера
    /// \param warningServiceModel   Модель сервиса окна-предупреждения
    public WarningServicePresenter(IWarningServiceModel warningServiceModel) => 
      _warningServiceModel = warningServiceModel;
    
    /// \brief Метод изменения состояния окна-предупреждения
    /// \param isOpen    true - окно открыто, false - окно закрыто
    public void SetState(bool isOpen) => 
      _warningServiceModel.SetState(isOpen);
  }
}