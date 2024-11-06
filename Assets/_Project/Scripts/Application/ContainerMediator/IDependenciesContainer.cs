using _Project.Scripts.Calculator;
using _Project.Scripts.WarningService;

namespace _Project.Scripts.Application.ContainerMediator
{
  public interface IDependenciesContainer
  {
    /// \brief Создание и получение зависимостей для данного состояния приложения
    void CreateApplicationStateDependencies(out IWarningService warningService, out ICalculator calculator);
    /// \brief Вызов очистки зависимостей для данного состояния приложения
    void CleanupApplicationStateDependencies();
  }
}