using _Project.Scripts.WarningService.Factories;
using _Project.Scripts.WarningService.Model;
using _Project.Scripts.WarningService.Presenter;
using VContainer;
using VContainer.Unity;

namespace _Project.Scripts.WarningService
{
  /// \class WarningServiceInstaller
  /// \brief Класс, отвечающий за инъекцию логики сервиса окна-предупреждения в приложение
  public class WarningServiceInstaller : IInstaller
  {
    /// \brief Метод конфигурации зависимостей сервиса окна-предупреждения
    public void Install(IContainerBuilder builder)
    {
      builder.Register<IWarningServiceModel, WarningServiceModel>(Lifetime.Scoped);
      builder.Register<IWarningServicePresenter, WarningServicePresenter>(Lifetime.Scoped);
      
      builder.Register<IWarningUIFactory, WarningUIFactory>(Lifetime.Scoped);
      builder.Register<IWarningService, WarningServiceLogic>(Lifetime.Scoped);
    }
  }
}