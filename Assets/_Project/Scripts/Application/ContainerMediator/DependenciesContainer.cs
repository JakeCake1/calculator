using _Project.Scripts.Application.StateMachine.ApplicationDependenciesInstaller;
using _Project.Scripts.Calculator;
using _Project.Scripts.Maths;
using _Project.Scripts.WarningService;
using VContainer;
using VContainer.Unity;

namespace _Project.Scripts.Application.ContainerMediator
{
  /// \class DependenciesContainer
  /// \brief Класс-посредник, связывающий логику приложения и DI Container
  public class DependenciesContainer : IDependenciesContainer
  {
    /// \brief Объект - глобальная область существования, содержащий регистрацию инъекций сервисов для всего времени жизни приложения
    private readonly ApplicationLifetimeScope _applicationLifetimeScope;
    /// \brief Объект - область существования, содержащий регистрацию инъекций логики для этого состояния приложения
    private LifetimeScope _applicationScope;
    
    /// \brief Конструктор посредника контейнера
    /// \param applicationLifetimeScope   Объект - глобальная область существования, содержащий регистрацию инъекций сервисов для всего времени жизни приложения
    public DependenciesContainer(ApplicationLifetimeScope applicationLifetimeScope) => 
      _applicationLifetimeScope = applicationLifetimeScope;

    /// \brief Создание и получение зависимостей для главного состояния приложения
    public void CreateApplicationStateDependencies(out IWarningService warningService, out ICalculator calculator)
    {
      _applicationScope = _applicationLifetimeScope.CreateChild(builder =>
      {
        new WarningServiceInstaller().Install(builder);
        new MathsInstaller().Install(builder);
        new CalculatorInstaller().Install(builder);
      });
      
      warningService = _applicationScope.Container.Resolve<IWarningService>();
      calculator = _applicationScope.Container.Resolve<ICalculator>();
    }
    
    /// \brief Вызов очистки зависимостей для главного состояния приложения
    public void CleanupApplicationStateDependencies()
    {
      _applicationScope.Dispose();
      _applicationScope = null;
    }
  }
}