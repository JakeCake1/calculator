using _Project.Scripts.WarningService.View;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.WarningService.Factories
{
  /// \interface IWarningUIFactory
  /// \brief Интерфейс, описывающий методы создания и уничтожения объектов UI сервиса окна-предупреждения
  public interface IWarningUIFactory
  {
    /// \brief Метод создания объекта UI сервиса окна-предупреждения
    /// \return UniTask который можно подождать до завершения процесса создания объекта
    UniTask<IWarningView> CreateWarningWindowView();
    /// \brief Метод уничтожения объекта UI сервиса окна-предупреждения
    void ClearWarningWindowView();
  }
}