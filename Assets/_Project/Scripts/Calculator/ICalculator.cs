using System;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Calculator
{  
  /// \interface ICalculator
  /// \brief Интерфейс, отвечающий за взаимодействие с логикой калькулятора
  public interface ICalculator
  {
    /// \brief Ивент появления ошибки в вычислениях
    event Action OnErrorOccurred;
    /// \brief Метод инициализации логики калькулятора
    /// \return UniTask который можно подождать до завершения процесса инициализации
    UniTask Initialize();
    /// \brief Метод активации/скрытия вида калькулятора
    /// \param isActive    Параметр true/false. Если true - вид отображается, false - вид скрыт
    void SetActive(bool isActive);
    /// \brief Метод завершения и очистки логики калькулятора
    void Quit();
  }
}