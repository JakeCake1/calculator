using System;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.WarningService
{
  /// \interface IWarningService
  /// \brief Интерфейс, отвечающий за появление окна-предупреждения
  public interface IWarningService
  {
    /// \brief Ивент закрытия окна
    event Action OnCloseWindow;
    /// \brief Метод инициализации сервиса окна-предупреждения
    /// \return UniTask который можно подождать до завершения процесса инициализации
    UniTask Initialize();
    /// \brief Метод активации/скрытия окна-предупреждения
    /// \param isActive    Параметр true/false. Если true - вид отображается, false - вид скрыт
    void OpenWindow();
    /// \brief Метод завершения и очистки сервиса окна-предупреждения
    void Quit();
  }
}