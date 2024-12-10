using _Project.Scripts.Calculator;
using _Project.Scripts.WarningService;

namespace _Project.Scripts.Application.ContainerMediator
{  
  /// \interface IDependenciesContainer
  /// \brief Интерфейс для посредника, связывающего логику приложения и DI Container
  public interface IDependenciesContainer
  {
    /// \brief Создание и получение зависимостей для главного состояния приложения
    void CreateApplicationStateDependencies(out IWarningService warningService, out ICalculator calculator);
    /// \brief Вызов очистки зависимостей для главного состояния приложения
    void CleanupApplicationStateDependencies();
  }
}