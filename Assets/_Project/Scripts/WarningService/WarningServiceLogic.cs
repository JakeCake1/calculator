using System;
using _Project.Scripts.WarningService.Factories;
using _Project.Scripts.WarningService.Model;
using _Project.Scripts.WarningService.Presenter;
using _Project.Scripts.WarningService.View;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.WarningService
{
  /// \class WarningServiceLogic
  /// \brief Класс, отвечающий за появление окна-предупреждения
  public class WarningServiceLogic : IWarningService
  {
    /// \brief Фабрика для создания UI окна-предупреждения
    private readonly IWarningUIFactory _warningUIFactory;

    /// \brief Презентер сервиса окна-предупреждения
    private readonly IWarningServicePresenter _warningServicePresenter;   
    /// \brief Модель данных сервиса окна-предупреждения
    private readonly IWarningServiceModel _warningServiceModel;
    
    /// \brief UI сервиса окна-предупреждения
    private IWarningView _warningWindowView;
    
    /// \brief Ивент закрытия сервиса окна-предупреждения
    public event Action OnCloseWindow;
    
    /// \brief Конструктор сервиса окна-предупреждения
    /// \param warningUIFactory   Фабрика для создания UI сервиса окна-предупреждения
    /// \param warningServicePresenter   Презентер сервиса окна-предупреждения
    /// \param warningServiceModel   Модель данных сервиса окна-предупреждения
    public WarningServiceLogic(IWarningUIFactory warningUIFactory, 
      IWarningServicePresenter warningServicePresenter, IWarningServiceModel warningServiceModel)
    {
      _warningServiceModel = warningServiceModel;
      _warningServicePresenter = warningServicePresenter;
      _warningUIFactory = warningUIFactory;
    }
    
    /// \brief Метод инициализации сервиса окна-предупреждения
    /// \return UniTask который можно подождать до завершения процесса инициализации
    public async UniTask Initialize()
    {   
      _warningWindowView = await _warningUIFactory.CreateWarningWindowView();

      _warningServiceModel.Init(_warningWindowView, OnCloseWindow);
      _warningWindowView.Init(_warningServicePresenter);
    }
    
    /// \brief Метод активации/скрытия окна-предупреждения
    /// \param isActive    Параметр true/false. Если true - вид отображается, false - вид скрыт
    public void OpenWindow() => 
      _warningWindowView.SetState(true);
    
    /// \brief Метод завершения и очистки сервиса окна-предупреждения
    public void Quit() => 
      _warningUIFactory.ClearWarningWindowView();
  }
}