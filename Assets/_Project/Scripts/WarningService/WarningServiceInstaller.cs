using _Project.Scripts.WarningService.Factories;
using _Project.Scripts.WarningService.Model;
using _Project.Scripts.WarningService.Presenter;
using VContainer;
using VContainer.Unity;

namespace _Project.Scripts.WarningService
{
  public class WarningServiceInstaller : IInstaller
  {
    public void Install(IContainerBuilder builder)
    {
      builder.Register<IWarningServiceModel, WarningServiceModel>(Lifetime.Singleton);
      builder.Register<IWarningServicePresenter, WarningServicePresenter>(Lifetime.Singleton);
      
      builder.Register<IWarningUIFactory, WarningUIFactory>(Lifetime.Singleton);
      builder.Register<IWarningService, WarningServiceLogic>(Lifetime.Singleton);
    }
  }
}